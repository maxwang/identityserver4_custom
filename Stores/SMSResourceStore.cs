using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using CustomDbProfileService2.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomDbProfileService2.Stores
{
	public class SMSResourceStore : SMSStoreBase, IResourceStore
	{
		public SMSResourceStore(Id4Context context) : base(context)
		{
		}

		public async Task<IdentityServer4.Models.ApiResource> FindApiResourceAsync(string name)
		{
			var result = await db.ApiResources.SingleOrDefaultAsync(x => x.Name == name);

			return result != null ? new IdentityServer4.Models.ApiResource()
			{
				Name = result.Name,
				DisplayName = result.DisplayName,
				Description = result.Description,
				ApiSecrets = GetApiSecrets(result.ApiSecrets),
				//UserClaims = GetApiClaims(result.UserClaims),
				Scopes = GetApiScopes(result.Scopes)
			} : null;
		}

		//for testing, ignore this now
		private ICollection<string> GetApiClaims(string userClaims)
		{
			return null;
		}

		//scope and role do it later
		private ICollection<Scope> GetApiScopes(string scopes)
		{
			return null;
		}

		private ICollection<Secret> GetApiSecrets(string apiSecrets)
		{
			return string.IsNullOrEmpty(apiSecrets) ? null : new List<Secret>() { new Secret(apiSecrets) };
		}

		//will change to main-detail table
		public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			

			List<IdentityServer4.Models.ApiResource> results = new List<IdentityServer4.Models.ApiResource>();

			foreach (var name in scopeNames)
			{
				var resources = await db.ApiResources.Where(x => x.Scopes.Contains(name)).Select(x =>
					new IdentityServer4.Models.ApiResource
					{
						Name = x.Name,
						DisplayName = x.DisplayName,
						Description = x.Description,
						ApiSecrets = GetApiSecrets(x.ApiSecrets),
						UserClaims = GetApiClaims(x.UserClaims),
						Scopes = GetApiScopes(x.Scopes)
					}
				).ToArrayAsync();
				results = results.Union(resources).ToList();
			}

			//return new List<IdentityServer4.Models.ApiResource>();
			return results;
			
		}

		//test first, do this later
		public async Task<IEnumerable<IdentityServer4.Models.IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
		{
			var results = await db.IdentityResources.ToListAsync();
			return new List<IdentityServer4.Models.IdentityResource>();
		}

		public async Task<Resources> GetAllResources()
		{
			var results = new Resources();

			var apiResources = await db.ApiResources.Select(x => new IdentityServer4.Models.ApiResource
			{
				Name = x.Name,
				DisplayName = x.DisplayName,
				Description = x.Description,
				ApiSecrets = GetApiSecrets(x.ApiSecrets),
				UserClaims = GetApiClaims(x.UserClaims),
				Scopes = GetApiScopes(x.Scopes)
			}).ToListAsync();

			results.ApiResources = (apiResources == null || apiResources.Count == 0) ?
				new List<IdentityServer4.Models.ApiResource>() :
				apiResources;

			results.IdentityResources = new List<IdentityServer4.Models.IdentityResource>();

			//ignore identity resource for testing


			return results;
		}
	}
}
