using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SourceControlFinalAssignment_1.Models
{
    public class UserContext:DbContext
    {
        public DbSet<User> User { get; set; }
    }
}