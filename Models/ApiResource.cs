using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDbProfileService2.Models
{
	[Table("ApiResource")]
	public class ApiResource
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }

		public string Name { get; set; }

		public string DisplayName { get; set; }
		public string Description { get; set; }
		public string ApiSecrets { get; set; }

		public string UserClaims { get; set; }
		public string Scopes { get; set; }
	}
}
