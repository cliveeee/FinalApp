using System.Collections.ObjectModel;
using Newtonsoft.Json;
using FinalApp.Model;

namespace FinalApp.ViewModels
{
    public class FootballClubsViewModel
    {
        public ObservableCollection<Clubs> ClubModels { get; set; }

        public FootballClubsViewModel()
        {
            ClubModels = new ObservableCollection<Clubs>();

            
            LoadDataFromApi();
        }

        private async void LoadDataFromApi()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string apiUrl = "https://www.thesportsdb.com/api/v1/json/3/lookuptable.php?l=4328&s=2023-2024";

                var response = await httpClient.GetStringAsync(apiUrl);

                
                LeagueData data = JsonConvert.DeserializeObject<LeagueData>(response);

                foreach (var club in data.table)
                {
                    var newClub = new Clubs
                    {
                        Position = int.Parse(club.intRank),
                        TeamName = club.strTeam,
                        GamesPlayed = int.Parse(club.intPlayed),
                        GamesWon = int.Parse(club.intWin),
                        GamesDrawn = int.Parse(club.intDraw),
                        GamesLost = int.Parse(club.intLoss),
                        GoalDifference = int.Parse(club.intGoalDifference),
                        Points = int.Parse(club.intPoints),
                        Logo = club.strTeamBadge
                    };

                    ClubModels.Add(newClub);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching data from API: " + ex.Message);
            }
        }

        public Clubs GetClub(string name)
        {
            foreach (var team in ClubModels)
            {
                if (team.TeamName != name) continue;
                return team;
            }
            return null;
        }

        
        public class LeagueData
        {
            public List<ClubInfo> table { get; set; }
        }

        public class ClubInfo
        {
            public string intRank { get; set; }
            public string strTeam { get; set; }
            public string intPlayed { get; set; }
            public string intWin { get; set; }
            public string intDraw { get; set; }
            public string intLoss { get; set; }
            public string intGoalDifference { get; set; }
            public string intPoints { get; set; }
            public string strTeamBadge { get; set; }
        }
    }
}
