using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EFCore
{
	class Program
	{
		static void Main(string[] args)

		{
			TeamManagement t = new TeamManagement();
			TeamMemManagement tm = new TeamMemManagement(); // W definicji tej klasy rozwiązany jest problem N+1
	
			Console.WriteLine("Wybierz operacje:\nPrzycisk 1 --> Wyswietl wszystkich zawodnikow (wraz z TEAM)\nPrzycisk 2 --> Usuń zespół");
			string operationSelect = Console.ReadLine();
		
			if (operationSelect == "1")   //LAZY LOADING ---> Dane są ładowanie w momencie, kiedy je potrzebujemy
			{
				
				tm.TeamsMembersProperty.ForEach(t => Console.WriteLine(t.FirstName+" "+t.LastName+" | team: "+t.Team.Name));
			}
			else if(operationSelect=="2")
			{
				Console.WriteLine("Podaj ID zespołu: ");
				string id = Console.ReadLine();

				// Więzy intergralności -------> Jeśli usuwam Team to ----> SET NULL w TeamMember
				t.DeleteTeam(Int32.Parse(id));

			}
			Console.ReadLine();


		}



	}
	
}
