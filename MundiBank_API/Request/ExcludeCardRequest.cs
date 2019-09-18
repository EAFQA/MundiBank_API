using FluentAssertions;
using MundiBank_API.Models;
using MundiBank_API.Models_Request;
using MundiBank_API.Utils;
using System;
using System.Collections.Generic;

namespace MundiBank_API.Request
{
    public class ExcludeCardRequest : BaseRequest<ExcludeCard_Response>
    {
        public ExcludeCardRequest() :
           base("https://dev.pinbank.com.br/Services/api/Transacoes/ExcluirCartao")
        {
            this.GetToken();
            this.GetIdCard();


            var obj = new ExcludeCard_Request
            {
                Data = new ExcludeCard_Request.Root
                {
                    CodigoCanal = 47,
                    CodigoCliente = 7309,
                    CartaoId = this.CartaoId
                }
            };

            this.Headers = new Dictionary<string, string>
            {
                { "UserName", "Yj3b0CsopkBR" },
                { "RequestOrigin", "5" },
                { "Authorization", $"bearer {this.Token}"},
                { "Content-Type", "application/json" }
        };
            this.Configure(obj);
            this.Send();
        }

        public override void Assert()
        {
            try
            {
                var result = this.Result;
                result.ResultCode.Should().Be(0);
                result.Message.Should().Be("Success");
            }
            catch (Exception)
            {
                Email.EnviarEmail();
                Environment.Exit(0);
            }
        }
    }
}
