using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomDbProfileService2.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomDbProfileService2.Validation
{
	public class SMSTokenValidator : SMSISBaseClass, ITokenValidator
	{
		public SMSTokenValidator(Id4Context context) : base(context)
		{
		}

		public async Task<TokenValidationResult> ValidateAccessTokenAsync(string token, string expectedScope = null)
		{
			var result = await db.Clients.SingleOrDefaultAsync(x => x.ClientId == "1");

			return new TokenValidationResult()
			{

			};

		}

		public async Task<TokenValidationResult> ValidateIdentityTokenAsync(string token, string clientId = null, bool validateLifetime = true)
		{
			var result = await db.Clients.SingleOrDefaultAsync(x => x.ClientId == "1");

			return new TokenValidationResult()
			{

			};
		}
	}
}
