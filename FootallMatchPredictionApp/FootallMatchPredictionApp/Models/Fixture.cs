using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FootallMatchPredictionApp.Models
{
    public class Fixture
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int MatchID { get; set; }
        public DateTime MatchDate { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public String Winner { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
