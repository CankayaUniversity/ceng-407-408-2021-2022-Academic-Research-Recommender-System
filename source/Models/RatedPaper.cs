using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CENG408.Models
{
    public class RatedPaper
    {
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string AvgRating { get; set; }
        public string PaperId { get; set; }
        public bool isRated { get; set; }
    }
}
