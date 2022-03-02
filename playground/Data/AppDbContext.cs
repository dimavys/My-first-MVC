using System;
using Microsoft.EntityFrameworkCore;
using playground.Models;
namespace playground.Data
{
	public class AppDbContext: DbContext
	{
        public DbSet<Task> Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}

