using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class GlobalChecker
    {


        public int id { get; set; }

        public int QuestionId { get; set; }

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public bool IsLiked { get; set; }

        public bool IsDisliked { get; set; }


    }
}

