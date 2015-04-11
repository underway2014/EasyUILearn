using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace EasyUILearn.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String PassWord { get; set; }
    }
    public class UserManagerDBContext:DbContext
    {
        public UserManagerDBContext()
            :base("UserSystem")
        {

        }
        public DbSet<UserModel> UserModels { get; set; }
    }
    
}