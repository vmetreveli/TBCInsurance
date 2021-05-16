using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Identity.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}