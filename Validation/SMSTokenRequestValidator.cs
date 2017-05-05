using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Collections.Specialized;
using CustomDbProfileService2.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomDbProfileService2.Validation
{
	public class SMSTokenRequestValidator : SMSISBaseClass, ITokenRequestValidator
	{
		

		public SMSTokenRequestValidator(Id4Context context) : base(context)
		{
			
		}

		public async Task<TokenRequestValidationResult> ValidateRequestAsync(NameValueCollection parameters, IdentityServer4.Models.Client client)
		{
		
			var result = await db.Clients.SingleOrDefaultAsync(x => x.ClientId == "1");
			//TokenRequestValidationResult result = new TokenRequestValidationResult(;
			return new TokenRequestValidationResult(null);

			//throw new NotImplementedException();
		}
	}
}
