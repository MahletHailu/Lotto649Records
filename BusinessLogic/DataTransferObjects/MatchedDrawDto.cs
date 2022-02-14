using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.DataTransferObjects
{
    public class MatchedDrawDto
    {
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int matchCount { get; set; }
        public double Won { get; set; }
    }
}
