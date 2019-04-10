using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{

    public class SessionElement
    {
        public int UserId { get; set; }
        public string UserNickname { get; set; }
        public User current { get; set; }
        public Dictionary<string, object> tmpData { get; } = new Dictionary<string, object>();

    }

    public class Session
    {
        public Dictionary<string, SessionElement> users = new Dictionary<string, SessionElement>();
    }
}
