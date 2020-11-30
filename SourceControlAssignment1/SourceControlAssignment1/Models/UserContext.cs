using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1.Models
{
    public class UserContext:DbContext
    {
        public DbSet<User> user { get; set; }
    }
}