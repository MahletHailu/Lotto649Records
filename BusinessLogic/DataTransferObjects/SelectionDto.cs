using System;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLogic.Models.DataTransferObjects
{
    /// <summary>
    /// Represents user selected numbers
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SelectionDto
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }
    }
}
