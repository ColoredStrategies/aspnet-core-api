using System.Text.Json.Serialization;

namespace aspnet_core_api.Models
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }

        [JsonIgnore]
        public string password { get; set; }
    }
}