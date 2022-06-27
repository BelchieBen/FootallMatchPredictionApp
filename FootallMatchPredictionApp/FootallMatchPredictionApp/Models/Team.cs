using System;
using System.Collections.Generic;
using System.Text;

namespace FootallMatchPredictionApp.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public String Name { get; set; }
        public String Logo { get; set; }
        public int LeaugeRank { get; set; }
        public String Coach { get; set; }
    }
}
