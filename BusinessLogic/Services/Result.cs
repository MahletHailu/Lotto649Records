using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Represents result obtained after checking historical data
    /// </summary>
    public class Result
    {
        /// <summary>
        /// List of draws matched with 4 or more numbers from the selection
        /// </summary>
        public List<MatchedDraw> MatchedDraws { get; set; }

        /// <summary>
        /// Todatl amount of money won according to matched draws
        /// </summary>
        public double TotalWon
        {
            get
            {
                return MatchedDraws.Sum(m => m.Won);
            }
        }

        /// <summary>
        /// Total amount of money spent to buy tickets
        /// </summary>
        public double TotalCost { get; set; }
    }
}
