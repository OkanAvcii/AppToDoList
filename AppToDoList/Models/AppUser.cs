using Microsoft.AspNetCore.Identity;

namespace AppToDoList.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
