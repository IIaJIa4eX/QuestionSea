﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class Answer
    {
        public int id { get; set; }

        public int QuestionId { get; set; }

        public int UserId { get; set; }

        public string AnswerText { get; set; }

        public bool BestAnswer { get; set; } = false;

        public int Rating { get; set; }

        public int Like { get; set; }

        public int Dislike { get; set; }

        public bool Deleted { get; set; } = false;

        public DateTime Date { get; set; }

        public string Picture { get; set; }


    }
}
