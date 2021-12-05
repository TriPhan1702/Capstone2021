using Newtonsoft.Json;

namespace HairCutAppAPI.Utilities.GoogleAuth
{
    public class FacebookAccessTokenResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("picture")]
        public string Picture { get; set; }
    }
}