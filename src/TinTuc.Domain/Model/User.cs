using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime Create { get; set; }

        public User()
        {
            Create = DateTime.Now;
        }
        public User(string name, string email, string password, string address)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
            Create = DateTime.Now;
        }
    }
}
