using Microsoft.AspNetCore.Authorization;
namespace Rockaway.WebApp.Authorization;

public static class AuthorizationPolicyExtensions {
	private static AuthorizationPolicy BuildEmailDomainPolicy(string domain) => new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.RequireEmailDomain(domain)
		.Build();

	public static IServiceCollection AddEmailDomainAuthorization(this IServiceCollection services,
		string policyName, string emailDomain) {
		var policy = BuildEmailDomainPolicy("rockaway.dev");
		services.AddAuthorization(options => options.AddPolicy(policyName, policy));
		return services;
	}

	public static AuthorizationPolicyBuilder RequireEmailDomain(this AuthorizationPolicyBuilder builder, string domain) {
		domain = domain.StartsWith("@") ? domain : $"@{domain}";
		return builder.RequireAssertion(ctx => {
			var email = ctx.User?.Identity?.Name ?? "";
			return email.EndsWith(domain, StringComparison.InvariantCultureIgnoreCase);
		});
	}
}