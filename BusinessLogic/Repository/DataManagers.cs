using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Models;
using BusinessLogic.Models.DataTransferObjects;
using BusinessLogic.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Repository
{
    public class DataManagers : IDataRepository<HistoricalDraws>
    {
        private readonly LottoRecordsContext _lottoRecordsContext;

        public DataManagers(LottoRecordsContext lottoRecordsContext)
        {
            _lottoRecordsContext = lottoRecordsContext
                ?? throw new ArgumentNullException(nameof(lottoRecordsContext));
        }

        /// <summary>
        /// <c>GetAllAsync</c>
        /// This async method gets all historical drwas that are valid
        /// </summary>
        /// <returns>Task<IEnumerable<HistoricalDraws>></returns
        async Task<IEnumerable<HistoricalDraws>> IDataRepository<HistoricalDraws>.GetAllAsync()
        {
            //Requirement explicitely mentioned to only consider historical drwas from 1 - 3620

            var draws = await _lottoRecordsContext.HistoricalDraws
                               .Where(d => d.DrawNumber <= 3620)
                               .ToListAsync();

            return draws;
        }

        /// <summary>
        /// Searches all records that match any of the 6 numbers from user selection
        /// </summary>
        /// <param name="selection"></param>
        /// <returns></returns>
        public async Task<IEnumerable<HistoricalDraws>> SearchAsync(Selection selection)
        {
            var draws = await _lottoRecordsContext.HistoricalDraws
                              .Where(d => d.DrawNumber <= 3620 &&
                                    (d.NumberDrawn1 == selection.Number1 ||
                                     d.NumberDrawn2 == selection.Number2 ||
                                     d.NumberDrawn3 == selection.Number3 ||
                                     d.NumberDrawn4 == selection.Number4 ||
                                     d.NumberDrawn5 == selection.Number5 ||
                                     d.NumberDrawn6 == selection.Number6))
                              .ToListAsync();
            return draws;
        }
    }
}
