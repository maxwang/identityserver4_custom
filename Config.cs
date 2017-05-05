using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace CustomDbProfileService2
{
	internal class Config
	{
		internal static IEnumerable<ApiResource> GetApis()
		{
			return new ApiResource[]
			{
				new ApiResource("api", "Some Api"),
				//new ApiResource
				//{
				//	Name = "complicated_api",
				//	ApiSecrets = {
				//		new Secret("secret".Sha256())
				//	},
				//	DisplayName = "Complicated API",
				//	UserClaims = { "name", "email" },
				//	Scopes =
				//	{
				//		new Scope("full_access")
				//		{
				//			UserClaims = {"role"}
				//		},
				//		new Scope("read_only")
				//	}
				//}
			};
		}

		internal static IEnumerable<Client> GetClients()
		{
			return new Client[]
		   {
				new Client
				{
					ClientId = "console",
					ClientName = "Console App",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets ={ new Secret("secret".Sha256()) },
					AllowedScopes = { "api" }
				}
		   };
		}
	}
}