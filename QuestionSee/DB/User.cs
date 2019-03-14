using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class User
    {
        public int id { get; set; }

        public string Nickname { get; set; }

        public string Name { get; set;}

        public string Password { get; set; } 

        public string SecondName { get; set; }

        public int Rating { get; set; } = 0;

        public string Email { get; set; } = "NONAME@fff.ff";

        public bool Status { get; set; } = false;

        public bool Admin { get; set; } = false;

        public bool Banned { get; set; } = false;

        public string ProfilePicture { get; set; } 



    }
}
