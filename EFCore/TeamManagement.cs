using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore
{
	class TeamManagement
	{ 
		TournamentContext _db;
		private Lazy<List<Team>> Teams { get; set; }
		public TeamManagement()
		{
			_db = new TournamentContext();
			Teams = new Lazy<List<Team>>(() => LoadTeams());
		}

		public void AddNewTeam(string firstName)
		{
			Team model = new Team { Name = firstName };
			_db.Team.Add(model);

		}
		public void DeleteTeam(int id)
		{
			Team model = new Team();
			
			model = _db.Team.Where(m => m.Id == id).FirstOrDefault();
			_db.Team.Remove(model);
			_db.SaveChanges();

		}
		private List<Team> LoadTeams()
		{
			List<Team> temp = new List<Team>();
			temp=_db.Team.ToList();
			return temp;
		}
		public List<Team> TeamsProperty
		{
			get
			{
				return Teams.Value;
			}
		}


		


	}
}
