using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ShoppingCart.IntegrationTests.AuthTests
{
    public class TestAuthHandlerOptions : AuthenticationSchemeOptions
    {
        public string? UserRole { get; set; }
    }

    public class TestAuthHandler : AuthenticationHandler<TestAuthHandlerOptions>
    {
        public const string AuthenticationScheme = "Test";
        private readonly string? _defaultUserRole;

        public TestAuthHandler(IOptionsMonitor<TestAuthHandlerOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _defaultUserRole = options.CurrentValue.UserRole;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new List<Claim>() { new Claim(ClaimTypes.Name, "Test user") };
            if(_defaultUserRole != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, _defaultUserRole));
            }
            var identity = new ClaimsIdentity(claims, AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, AuthenticationScheme);

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
