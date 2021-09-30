using Newtonsoft.Json;

namespace HairCutAppAPI.Utilities.GoogleAuth
{
    public class GoogleIdTokenResponse
    {
        [JsonProperty("email")]
        public string Email;
        //The Issuer Identifier for the Issuer of the response. Always https://accounts.google.com or accounts.google.com for Google ID tokens.
        [JsonProperty("iss")]
        public string Iss;
        //The time the ID token was issued, represented in Unix time (integer seconds).
        [JsonProperty("iat")]
        public string Iat;
        /// Identifies the audience that this ID token is intended for. It must be one of the OAuth 2.0 client IDs of your application.
        [JsonProperty("aud")]
        public string Aud { get; set; }
        //The time the ID token expires, represented in Unix time (integer seconds).
        [JsonProperty("exp")]
        public string Exp;
        //True if the user's e-mail address has been verified; otherwise false.
        [JsonProperty("email_verified")]
        public bool EmailVerified;
    }
}