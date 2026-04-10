using System.Net.Http.Headers;
using System.Text.Json;

namespace ScoreFetch.Backend.Models
{
    public class GameInfo
    {
        public string HomeName { get; set; }
        public int HomeScore { get; set; }

        public string AwayName { get; set; }
        public int AwayScore { get; set; }

        public int GamePeriod { get; set; }
        public string ClockTime { get; set; }

        public string GameDate { get; set; }
        public string GameTime { get; set; }

        public GameInfo(string homeName, int homeScore, string awayName, int awayScore, int gamePeriod, string clockTime, string gameDate, string gameTime)
        {
            HomeName = homeName;
            HomeScore = homeScore;
            AwayName = awayName;
            AwayScore = awayScore;
            GamePeriod = gamePeriod;
            ClockTime = clockTime;
            GameDate = gameDate;
            GameTime = gameTime;
        }

        public JsonContent ToJsonContent()
        {
            var json = JsonSerializer.Serialize(this);
            return JsonContent.Create(json, new MediaTypeHeaderValue("application/json"));
        }
    }
}

