using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fireiceproj.Models;

namespace fireiceproj.Data
{
    public class fireiceprojContext : DbContext
    {
        public fireiceprojContext (DbContextOptions<fireiceprojContext> options)
            : base(options)
        {
        }

        public DbSet<fireiceproj.Models.Queries> Queries { get; set; }
    }
}
