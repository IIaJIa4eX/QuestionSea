using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace QuestionSee.Models
{
    public class BaseModel
    {
        public DB.User user { get; set; }
    }
}
