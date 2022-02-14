using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BusinessLogic.Models
{
    public partial class HistoricalDraws
    {
        public int DrawNumber { get; set; }
        public int SequenceNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int NumberDrawn1 { get; set; }
        public int NumberDrawn2 { get; set; }
        public int NumberDrawn3 { get; set; }
        public int NumberDrawn4 { get; set; }
        public int NumberDrawn5 { get; set; }
        public int NumberDrawn6 { get; set; }
        public int BonusNumber { get; set; }
    }
}
