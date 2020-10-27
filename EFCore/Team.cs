using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore
{
	class Team
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
