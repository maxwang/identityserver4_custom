using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomDbProfileService2.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;

namespace CustomDbProfileService2.Validation
{
	public class SMSCustomAuthorizeRequestValidator : SMSISBaseClass, ICustomAuthorizeRequestValidator
	{
		public SMSCustomAuthorizeRequestValidator(Id4Context context) : base(context)
		{
		}

		public async Task<AuthorizeRequestValidationResult> ValidateAsync(ValidatedAuthorizeRequest request)
		{
			var result = await db.Clients.SingleOrDefaultAsync(x => x.ClientId == "1");
			return new AuthorizeRequestValidationResult();
		}
	}
}
