using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;
namespace CleanArchitecture.Domain.Identity.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }

        public int EmailConfirmed { get; set; } = 1;

        [IgnoreDataMember]
        public string FullName => $"{FirstName} {LastName}";
    }
}