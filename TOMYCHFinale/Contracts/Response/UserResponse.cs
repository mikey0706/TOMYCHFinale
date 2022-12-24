using Common.Enums;
using Microsoft.AspNetCore.Identity;
using Services.BusinessObjects;

namespace TOMYCHFinale.Contracts.Response
{
    public class UserResponse 
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleTypes Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool EmailConfirmed { get; set; }
        public ICollection<SupportRequestResponse> Requests { get; set; }
    }
}
