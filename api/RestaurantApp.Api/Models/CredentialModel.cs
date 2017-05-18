using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Api.Models
{
    public class CredentialModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}