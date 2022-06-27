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
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Winner { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
