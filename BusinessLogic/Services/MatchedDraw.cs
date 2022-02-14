using System;

namespace BusinessLogic.Services
{
    /// <summary>
    /// a historial draw that matched selection
    /// </summary>
    public class MatchedDraw
    {
        /// <summary>
        /// DrawNumber of the historial draw
        /// </summary>
        public int DrawNumber { get; set; }

        /// <summary>
        /// Date of the historial draw
        /// </summary>
        public DateTime DrawDate { get; set; }

        /// <summary>
        /// count of numbers matched
        /// </summary>
        public int matchCount { get; set; }

        /// <summary>
        /// Amount of money won according to matched numbers
        /// </summary>
        public double Won
        {
            get
            {
                var total = matchCount switch
                {
                    4 => 85,
                    5 => 3000,
                    6 => 5000000,
                    _ => 0
                };

                return total;
            }
        }
    }
}
