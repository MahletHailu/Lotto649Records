using System;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.DataTransferObjects
{
    /// <summary>
    /// Represents result
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ResultDto
    {
        public MatchedDrawDto[] MatchedDraws { get; set; }

        public double TotalWon { get; set; }
        public double TotalCost { get; set; }
    }
}
