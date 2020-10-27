using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore
{
	class TeamMemManagement
	{
		TournamentContext _db;
		private Lazy<List<TeamMember>> TeamMembers { get; set; }
		public TeamMemManagement()
		{
			_db = new TournamentContext();
			TeamMembers= new Lazy<List<TeamMember>>(() => LoadTeamMembers());


		}
		public List<TeamMember> TeamsMembersProperty
		{
			get
			{
				return TeamMembers.Value;
			}
		}
		private List<TeamMember>LoadTeamMembers()
		{
		
			List<TeamMember> tm = new List<TeamMember>();

			// PROBLEM N+1 ----> Wysyłane jest jedno zapytanie, które zwróci wszystkie potrzebne dane
			tm = _db.TeamMembers.Include(t => t.Team).ToList();   
			return tm;
			

		}

	}
}
