using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class Question
    {
        public int Id { get; set; } = 3;

        public int UserId { get; set; } = 1;

        public string Header { get; set; } = "Test";

        public string Description { get; set; } = "TesTestTestTestTestTestTestTestt";

        public string Tag { get; set; } = "Test";

        public bool Answered { get; set; } = true;

        public int Rating { get; set; } = 135;

        public int Like { get; set; } = 5;

        public bool Deleted { get; set; } = false;

        public int Dislike { get; set; } = 3;

        public DateTime Date { get; set; }


    }
}
