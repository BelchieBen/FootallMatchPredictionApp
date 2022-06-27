using System;
using System.Collections.Generic;
using System.Text;

namespace FootallMatchPredictionApp.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public int LeaugeRank { get; set; }
        public string Coach { get; set; }
    }
}
