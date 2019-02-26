using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int score { get; set; }

        public bool login = false;

    }
}
