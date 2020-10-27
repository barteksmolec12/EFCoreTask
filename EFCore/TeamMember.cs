using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCore
{
	class TeamMember
	{
		[Required]
		public int Id { get; set; }
	
		public int? TeamId { get; set; }
		
		[ForeignKey("TeamId")]
		public virtual Team Team { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Title { get; set; }
		
	
	}
	public enum ETitles
	{
		Developer = 1, ScrumMaster = 2, ProjectOwner = 3

	}
}
