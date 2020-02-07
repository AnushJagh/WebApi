using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebApiApp.Model
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions options):base(options)
        {

        }
     
        public DbSet<Student> Students { get; set; }
    }
}
