using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDbProfileService2.Models
{
    public class Id4Context : DbContext
    {
		public Id4Context(DbContextOptions<Id4Context> options) : base(options)
		{
			
		}

		public DbSet<Client> Clients { get; set; }
		public DbSet<IdentityResource> IdentityResources { get; set; }
		public DbSet<ApiResource> ApiResources { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Client>().ToTable("Clients");
		}
	}
}
