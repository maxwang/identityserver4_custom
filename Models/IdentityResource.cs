using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDbProfileService2.Models
{
	[Table("IdentityResource")]
	public class IdentityResource
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }

		public string Name { get; set; }

		public string DisplayName { get; set; }
		public string Description { get; set; }
		
		public bool Required { get; set; }
		public bool Enabled { get; set; }
		public bool Emphasize { get; set; }
		public bool ShowInDiscoveryDocument { get; set; }

		public string UserClaims { get; set; }

	}
}
