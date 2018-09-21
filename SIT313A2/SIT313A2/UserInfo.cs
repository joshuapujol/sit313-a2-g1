using Newtonsoft.Json;

namespace SIT313A2
{
    [JsonObject]
    class UserInfo
    {
        // This class handles the login data locally and decodes from the JSON login response.
        // If any types are not needed, commenting them out will reduce resource usage.
        [JsonProperty("id")]
        public string Id
        {
            get;
            set;
        }
        [JsonProperty("email")]
        public string Email
        {
            get;
            set;
        }
        [JsonProperty("verified_email")]
        public bool VerifiedEmail
        {
            get;
            set;
        }
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
        [JsonProperty("given_name")]
        public string GivenName
        {
            get;
            set;
        }
        [JsonProperty("family_name")]
        public string FamilyName
        {
            get;
            set;
        }
        [JsonProperty("link")]
        public string Link
        {
            get;
            set;
        }
        [JsonProperty("picture")]
        public string Picture
        {
            get;
            set;
        }
        [JsonProperty("gender")]
        public string Gender
        {
            get;
            set;
        }
    }
}
