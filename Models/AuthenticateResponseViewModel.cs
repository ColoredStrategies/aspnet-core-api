namespace aspnet_core_api.Models
{
    public class AuthenticateResponseViewModel
    {
         public int id { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string token { get; set; }


        public AuthenticateResponseViewModel(User user, string token)
        {
            id = user.id;
            email = user.email;
            fullname = user.fullname;
            username = user.username;
            this.token = token;
        }
    }
}