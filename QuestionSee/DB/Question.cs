using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class Question
    {
        public int id { get; set; }

        public int UserId { get; set; }

        public string Header { get; set; }

        public string Desription { get; set; }

        public string Tag { get; set; }

        public bool Answered { get; set; }

        public int Rating { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public DateTime Date { get; set; } 


    }
}
