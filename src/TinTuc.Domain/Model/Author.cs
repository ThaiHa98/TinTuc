﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinTuc.Domain.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 

        public Author(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
