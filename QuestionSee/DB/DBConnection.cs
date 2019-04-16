using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionSee.DB
{
    public class DBConnection: DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=vtest.fvds.ru;Database=questionsee;Uid=newuser;Pwd=qwertypassword;CharSet=utf8;");
            //optionsBuilder.UseMySql("Server=localhost;Database=questionsee;Uid=root;Pwd=;CharSet=utf8;");
        }
    }
}
