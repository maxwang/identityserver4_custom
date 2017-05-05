using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDbProfileService2.Models
{
	[Table("Client")]
	public class Client
    {
		//[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("Id")]
		public int Id { get; set; }
		public string ClientId { get; set; }
		public string ClientName { get; set; }
		public string ClientSecrets { get; set; }
		public string AllowedGrantTypes { get; set; }

	}
}
