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
	public class SMSClientStore : SMSStoreBase, IClientStore
	{

		public SMSClientStore(Id4Context context) : base(context)
		{

		}
		

		public async Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
		{
			var result = await db.Clients.SingleOrDefaultAsync( x => x.ClientId == clientId);

			return result != null ? new IdentityServer4.Models.Client()
			{
				ClientId = result.ClientId,
				ClientName = result.ClientName,
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				AccessTokenLifetime = 60 * 60 * 2,
				//RequireClientSecret = false,
				ClientSecrets = { new Secret(result.ClientSecrets) },
				AllowedScopes = { "api" }
			} : null;


			//return result != null ? new IdentityServer4.Models.Client()
			//{
			//	ClientId = result.ClientId,
			//	ClientName = result.ClientName,
			//	AllowedGrantTypes = GrantTypes.ClientCredentials,
			//	AccessTokenLifetime = 60 * 60 * 2,
			//	RequireClientSecret = false,
			//	ClientSecrets = { new Secret("thisisatest".Sha256()) },
			//	AllowedScopes = { "api" }
			//} : null;
		}
	}
}
