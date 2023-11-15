using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FinalApp.Models;
using Newtonsoft.Json;

namespace FinalApp.ViewModels
{
    public class FixturesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Fixture> Fixtures { get; set; }
        public string CurrentMatchdayText => $"Game Week {CurrentMatchday}";

        public ICommand IncrementMatchdayCommand { get; private set; }
        public ICommand DecrementMatchdayCommand { get; private set; }

        private int _currentMatchday;
        public int CurrentMatchday
        {
            get { return _currentMatchday; }
            set
            {
                if (_currentMatchday != value)
                {
                    _currentMatchday = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(CurrentMatchdayText)); 
                    LoadFixturesFromApi();
                }
            }
        }

        public FixturesViewModel()
        {
            Fixtures = new ObservableCollection<Fixture>();
            CurrentMatchday = 13; 
            IncrementMatchdayCommand = new Command(IncrementMatchday);
            DecrementMatchdayCommand = new Command(DecrementMatchday);
            LoadFixturesFromApi();
        }

        private async void LoadFixturesFromApi()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                // Updating the API URL with the current matchday
                string apiUrl = $"https://www.thesportsdb.com/api/v1/json/3/eventsround.php?id=4328&r={CurrentMatchday}&s=2023-2024";

                var response = await httpClient.GetStringAsync(apiUrl);

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
                if (apiResponse?.Events != null)
                {
                    var sortedFixtures = apiResponse.Events
                        .Select(eventData => new Fixture
                        {
                            Team1Name = eventData.StrHomeTeam,
                            Team2Name = eventData.StrAwayTeam,
                            MatchDay = DateTimeFormatter.FormatDate(eventData.dateEvent, TimeZoneInfo.Local),
                            MatchTime = DateTimeFormatter.FormatTime(eventData.StrTime, TimeZoneInfo.Local),
                            Team1Logo = eventData.StrTeamBadge,
                            Team2Logo = eventData.StrTeamBadge,
                            Venue = eventData.strVenue
                        })
                        .OrderBy(f => DateTime.Parse(f.MatchDay + " " + f.MatchTime))
                        .ToList();

                    Fixtures.Clear(); 
                    foreach (var fixture in sortedFixtures)
                    {
                        Fixtures.Add(fixture);
                    }

                    OnPropertyChanged(nameof(Fixtures)); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching fixtures from API: " + ex.Message);
            }
        }

        private void IncrementMatchday()
        {
            if (CurrentMatchday < 38) 
            {
                CurrentMatchday++;
            }
        }

        private void DecrementMatchday()
        {
            if (CurrentMatchday > 1)
            {
                CurrentMatchday--;
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
