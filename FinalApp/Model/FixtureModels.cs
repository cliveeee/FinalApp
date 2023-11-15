using System;

namespace FinalApp.Models
    {
        public class ApiResponse
        {
            public List<FixtureData> Events { get; set; }
        }

        public class FixtureData
        {
            public string StrHomeTeam { get; set; }
            public string StrAwayTeam { get; set; }
            public string dateEvent { get; set; }
            public string StrTime { get; set; }
            public string strVenue { get; set; }
            public string strStatus { get; set; }
            public string strPostponed { get; set; }
            public string StrTeamBadge { get; set; }
            public string StrThumb { get; set; }

        }

        public class Fixture
        {
            public string Team1Name { get; set; }
            public string Team2Name { get; set; }
            public string MatchTime { get; set; }
            public string MatchDay { get; set; }
            public string Venue { get; set; }
            public string Team1Logo { get; set; }
            public string Team2Logo { get; set; }
        }
    }



