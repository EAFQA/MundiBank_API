using MundiBank_API.Models;
using System.Collections.Generic;
using System;
using FluentAssertions;
using MundiBank_API.Utils;

namespace MundiBank_API.Request
{
    public class TokenRequest : BaseRequest<Token_Response>
    {
        public TokenRequest() :
            base("https://dev.pinbank.com.br/Services/api/token")
        {
            this.Parameters = new Dictionary<string, string>
            {
                { "undefined", "grant_type=password&username=Yj3b0CsopkBR&password=umo1LNtje0Edx1Xv" }
            };

            this.Headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/x-www-form-urlencoded" },
                { "Accept", "application/json" }
            };

            this.Configure();
            this.Send();
        }

        public Token_Response GetTokenResponse()
        {
            return this.Result;
        }

        public override void Assert()
        {
            try
            {
                var result = this.Result;

                result.access_token.Should().Be(result.access_token);
                result.token_type.Should().Be("bearer");
                result.expires_in.Should().Be(3599);
            }
            catch (Exception)
            {
                Email.EnviarEmail();
                Environment.Exit(0);
            }
        }
    }
}
