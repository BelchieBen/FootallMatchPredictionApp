using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using FootallMatchPredictionApp.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace FootallMatchPredictionApp.Services
{
    public class FixtureDataStore: IFixtureDataStore<Fixture>
    {
        readonly SQLiteAsyncConnection database;
        private FootballAPI footballAPI;
        private HttpClient client;

        public FixtureDataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Fixture>().Wait();
            client = new HttpClient();
            footballAPI = new FootballAPI();
        }

        public Task<int> AddFixtureAsync(Fixture fixture)
        {
            if(fixture.ID != 0)
            {
                return database.UpdateAsync(fixture);
            }
            else
            {
                return database.InsertAsync(fixture);
            }
        }

        public Task<int> DeleteFixtureAsync(Fixture fixture)
        {
            return database.DeleteAsync(fixture);
        }

        public Task<Fixture> GetFixtureAsync(int id)
        {
            return database.Table<Fixture>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<List<Fixture>> GetFixturesAsync(bool forceRefresh = false)
        {
            return database.Table<Fixture>().ToListAsync();
        }

        public void RefreshFixturesAsync()
        {
            /*Uri uri = new Uri(string.Format(footballAPI.GetPLMatchesEndpoint, string.Empty));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(footballAPI.APIKey);
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                json
                var fixtures = JsonConvert.DeserializeObject(content);
                foreach(Fixture fixture in fixtures)
                {
                    await AddFixtureAsync(fixture);
                }
            }*/

            var url = footballAPI.GetPLMatchesEndpoint;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Accept = "application/json";
            httpRequest.Headers["X-Auth-Token"] = "880a476924bc4cdaa32e0c0e177fc0a3";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                JObject json = JObject.Parse(result);
                JToken matches = json.SelectToken("matches");
                var matchesArray = JArray.Parse(matches.ToString());
                var list = matchesArray.ToList();
                foreach (JObject match in list)
                {
                    Fixture fixture = new Fixture();
                    fixture.MatchID = (int)match.SelectToken("id");
                    fixture.MatchDate = (DateTime)match.SelectToken("utcDate");
                    fixture.HomeTeam = match.SelectToken("homeTeam").SelectToken("name").ToString();
                    fixture.AwayTeam = match.SelectToken("awayTeam").SelectToken("name").ToString();
                    fixture.Winner = match.SelectToken("score").SelectToken("winner").ToString();
                    fixture.HomeScore = (int)match.SelectToken("score").SelectToken("fullTime").SelectToken("home") ?? 0;
                    fixture.HomeScore = (int)match.SelectToken("score").SelectToken("fullTime").SelectToken("home");
                    AddFixtureAsync(fixture);
                }
            }
        }
    }
}
