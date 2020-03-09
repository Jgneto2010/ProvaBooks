using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string firstName, string lastName, int telephone, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            Telephone = telephone;
            Email = email;
            Address = address;
        }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
