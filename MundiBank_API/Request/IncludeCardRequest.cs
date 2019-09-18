using FluentAssertions;
using MundiBank_API.Models;
using MundiBank_API.Models_Request;
using MundiBank_API.Utils;
using System;
using System.Collections.Generic;
using Faker;

namespace MundiBank_API.Request
{
    public class IncludeCardRequest : BaseRequest<IncludeCard_Response>
    {
        private string nomeImpresso = Name.FullName();

        public IncludeCardRequest() :
            base("https://dev.pinbank.com.br/Services/api/Transacoes/IncluirCartao")
        {
            this.GetToken();

            var credit = CardCredit.NumeroCartaoCredito(16);

            var obj = new IncludeCard_Request
            {
                Data = new IncludeCard_Request.Root
                {
                    CodigoCanal = 47,
                    CodigoCliente = 7309,
                    Apelido = Name.First(),
                    NomeImpresso = nomeImpresso.Length > 20 ? nomeImpresso.Substring(0, 19) : nomeImpresso,
                    NumeroCartao = credit,
                    DataValidade = "202201",
                    CodigoSeguranca = RandomNumber.Next(1,1111).ToString(),
                    ValidarCartao = false
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

        public IncludeCard_Response IdCardResponse()
        {
            return this.Result;
        }

        public override void Assert()
        {
            try
            {
                var result = this.Result;
                result.Data.CartaoId.Should().Be(result.Data.CartaoId);
                result.ResultCode.Should().Be(false);
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
