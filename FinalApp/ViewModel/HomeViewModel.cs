using Newtonsoft.Json;
using System.Windows.Input;
using FinalApp.Model;

namespace FinalApp.ViewModel
{
    public class HomeViewModel
    {
        public List<NewsArticle> NewsArticles { get; private set; } = new List<NewsArticle>();

        public ICommand OpenArticleCommand { get; private set; }

        public HomeViewModel()
        {
            OpenArticleCommand = new Command<string>(async (url) => await OpenArticleAsync(url));
        }

        public async Task LoadDataFromApiAsync()
        {
            HttpClient client = new HttpClient();

            string apiUrl = "https://newsapi.org/v2/top-headlines?country=gb&category=sports&apiKey=245a6d03932f438aa85f213158ddc83e";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);

                if (apiResponse.Articles != null)
                {
                    NewsArticles = apiResponse.Articles;
                }
            }
        }

        private async Task OpenArticleAsync(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
            }
        }
    }
}
