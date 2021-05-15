using System.ComponentModel.DataAnnotations;
namespace CleanArchitecture.Domain.Models.Entities
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}