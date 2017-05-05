using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Extensions;

namespace CustomDbProfileService2
{
	public class SMSProfileService : IProfileService
	{
		public Task GetProfileDataAsync(ProfileDataRequestContext context)
		{
			var subjectId = context.Subject.GetSubjectId();

			//should get it from database
			var user = new
			{
				Id = "12345",
				Name = "John Smith"
			};

			var claims = new List<Claim>
			{
				new Claim(JwtClaimTypes.Subject, user.Id),
				new Claim(JwtClaimTypes.Name, user.Name),
				new Claim(JwtClaimTypes.GivenName, "John"),
				new Claim(JwtClaimTypes.FamilyName, "Smith"),
				new Claim(JwtClaimTypes.Email, "test@test.com"),
				new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
			};

			context.IssuedClaims = claims;

			return Task.FromResult(0);
		}

		public Task IsActiveAsync(IsActiveContext context)
		{
			var user = new
			{
				IsActive = true
			};

			context.IsActive = (user != null) && user.IsActive;

			return Task.FromResult(0);
		}
	}
}
