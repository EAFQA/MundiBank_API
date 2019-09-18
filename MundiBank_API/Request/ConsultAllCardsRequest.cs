using System;
using System.Collections.Generic;
using FluentAssertions;
using MundiBank_API.Models;
using MundiBank_API.Models_Request;
using MundiBank_API.Utils;

namespace MundiBank_API.Request
{
    public class ConsultAllCardsRequest : BaseRequest<ConsultAllCards_Response>
    {
        public ConsultAllCardsRequest() :
            base("https://dev.pinbank.com.br/Services/api/Transacoes/ConsultarCartoes")
        {
            this.GetToken();

            var obj = new ConsultAllCards_Request
            {
                Data = new ConsultAllCards_Request.Root
                {
                    CodigoCanal = 47,
                    CodigoCliente = 7309,
                   StatusCartao = "Todos"
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

                result.Apelido.Should().Be(result.Apelido);
                result.DataValidade.Should().Be(result.DataValidade);
                result.CartaoId.Should().Be(result.CartaoId);
                result.Status.Should().Be(null);
                result.NomeImpresso.Should().Be(result.NomeImpresso);
            }
            catch (Exception)
            {
                Email.EnviarEmail();
                Environment.Exit(0);
            }

        }
    }
}
