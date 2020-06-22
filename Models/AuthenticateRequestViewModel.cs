using System.ComponentModel.DataAnnotations;

namespace aspnet_core_api.Models
{
    public class AuthenticateRequestViewModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}