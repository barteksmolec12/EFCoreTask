using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
	class TournamentContext:DbContext
	{
		public static readonly ILoggerFactory MyLoggerFactory =
		LoggerFactory.Create(
		builder =>
		{
			builder.AddConsole();
		}
   );
		public DbSet<Team> Team { get; set; }
		public DbSet<TeamMember> TeamMembers { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
			   .UseLoggerFactory(MyLoggerFactory)
			   .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Tournament;AttachDbFilename=|DataDirectory|Tournament.mdf;Integrated Security=True;Trusted_Connection=True;"); 
		}
	}
}
