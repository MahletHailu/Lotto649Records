using BusinessLogic.Models.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Repository;
using BusinessLogic.Models;
using System;
using System.Linq;
using BusinessLogic.Models.Services;
using BusinessLogic.DataTransferObjects;

namespace BusinessLogic.Services
{
    public class ResultProcessor : IResultProcessor<ResultDto>
    {
        private readonly IDataRepository<HistoricalDraws> _dataRepository;

        public ResultProcessor(IDataRepository<HistoricalDraws> dataRepository)
        {
            _dataRepository = dataRepository
               ?? throw new ArgumentNullException(nameof(dataRepository));
        }

        /// <summary>
        /// This function calculates matched draws worth of $85 or more.
        /// </summary>
        /// <param name="selection"></param>
        /// <returns>ResultDto</returns>
        public async Task<ResultDto> ProcessResult(SelectionDto selection)
        {
            // SearchAsync gets all historical draws where any of the 6 numbers matches with the user selection
            var historyDraws =
                 await _dataRepository.SearchAsync(MapSelectionDtoToModel(selection));

            var matches = getValidMatches(MapSelectionDtoToModel(selection), historyDraws.ToList());

            var result = new Result
            {
                MatchedDraws = matches,
                TotalCost = await GetTotalCost()
            };

            return MapResultToDto(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selection"></param>
        /// <param name="draws"></param>
        /// <returns></returns>
        private List<MatchedDraw> getValidMatches(Selection selection, List<HistoricalDraws> draws)
        {
            var matched = new List<MatchedDraw>();

            var matchCount = 0;

            foreach (var draw in draws)
            {
                if (draw.NumberDrawn1 == selection.Number1)
                {
                    matchCount = matchCount + 1;
                }

                if (draw.NumberDrawn2 == selection.Number2)
                {
                    matchCount = matchCount + 1;
                }

                if (draw.NumberDrawn3 == selection.Number3)
                {
                    matchCount = matchCount + 1;
                }

                if (draw.NumberDrawn4 == selection.Number4)
                {
                    matchCount = matchCount + 1;
                }

                if (draw.NumberDrawn5 == selection.Number5)
                {
                    matchCount = matchCount + 1;
                }

                if (draw.NumberDrawn6 == selection.Number6)
                {
                    matchCount = matchCount + 1;
                }

                // Accorging to the requirement, only consider a match to be valid if 4 or more numbers matched($85 or more), otherwise ignore

                if (matchCount > 3)
                {
                    matched.Add(
                        new MatchedDraw
                        {
                            DrawNumber = draw.DrawNumber,
                            matchCount = matchCount,
                            DrawDate = draw.DrawDate
                        });
                }

                matchCount = 0;
            }

            return matched;
        }

        /// <summary>
        /// This function calculates total cost from all draws with draw number < 3620
        /// </summary>
        /// <returns>ResultDto</returns>
        private async Task<double> GetTotalCost()
        {
            // The assumption is that total cost will be based on historial records with drwa number 3620

            var allValidHistorialDraws =
                 await _dataRepository.GetAllAsync();

            // Calculate the cost based on the draw number as per requirement

            var totalCost = 0;

            foreach (HistoricalDraws draw in allValidHistorialDraws)
            {
                if (draw.DrawNumber <= 2124)
                {
                    totalCost = totalCost + 1;
                }
                else if (draw.DrawNumber > 2124 && draw.DrawNumber > 2989)
                {
                    totalCost = totalCost + 2;
                }
                else
                {
                    totalCost = totalCost + 3;
                }
            }

            return totalCost;
        }

        /// <summary>
        /// <c></c>
        /// A mapping utility function to map selction dto to Model
        /// </summary>
        /// <param name="selction"></param>
        /// <returns></returns
        private Selection MapSelectionDtoToModel(SelectionDto selectionDto)
        {
            var selection = (selectionDto != null) ? new Selection
            {
                Number1 = selectionDto.Number1,
                Number2 = selectionDto.Number2,
                Number3 = selectionDto.Number3,
                Number4 = selectionDto.Number4,
                Number5 = selectionDto.Number5,
                Number6 = selectionDto.Number6,
            }
            : null;

            return selection;
        }

        /// <summary>
        /// <c>MapToDto</c>
        /// A mapping utility function to map MatchedDraw to MatchedDrawDto
        /// </summary>
        /// <param name="MatchedDraw"></param>
        /// <returns></returns
        private MatchedDrawDto MapMatchedDrawToDto(MatchedDraw matchedDraw)
        {
            var MatchedDrawDto = (matchedDraw != null) ? new MatchedDrawDto
            {
                DrawNumber = matchedDraw.DrawNumber,
                DrawDate = matchedDraw.DrawDate,
                matchCount = matchedDraw.matchCount,
                Won = matchedDraw.Won
            }
            : null;

            return MatchedDrawDto;
        }

        /// <summary>
        /// <c>MapToDto</c>
        /// A mapping utility function to map Result to ResultDto
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns
        private ResultDto MapResultToDto(Result result)
        {
            var resultDto = (result != null) ? new ResultDto
            {
                MatchedDraws = result.MatchedDraws.Select(b => MapMatchedDrawToDto(b)).ToArray(),
                TotalCost = result.TotalCost,
                TotalWon = result.TotalWon
            }
            : null;

            return resultDto;
        }
    }
}
