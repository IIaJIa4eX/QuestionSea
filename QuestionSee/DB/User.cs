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

        public int Rating { get; set; }

        public int Asked { get; set; }

        public int Answered { get; set; }

        public int BestAnswersCount { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }

        public bool Admin { get; set; }

        public bool Banned { get; set; }

        public string ProfilePicture { get; set; } 



    }
}
