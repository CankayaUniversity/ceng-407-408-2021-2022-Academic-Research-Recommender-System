using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hypercorrect.Models
{
    public class paperDetail
    {
        public Paper SelectedPaper { get; set; }
        public List<PapersTask> TaskList { get; set; }
        public List<Papers7> RelatedPaperList { get; set; }
    }
}
