using Faker;
using FluentAssertions;
using MundiBank_API.Models;
using MundiBank_API.Models_Request;
using MundiBank_API.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Request
{
    public class GenerateBulletRequest : BaseRequest<Generate_Bullet_Response>
    {
        public GenerateBulletRequest() :
            base("https://dev.pinbank.com.br/Services/api/CashIn/GerarBoleto")
        {
            this.GetToken();

            var obj = new GenerateBullet_Request
            {
                Data = new GenerateBullet_Request.Root
                {
                    CodigoCanal = 47,
                    CodigoCliente = 7309,
                    DataVencimento = "20191030",
                    Valor = 999,
                    Email = "eduardo.andrade@mundibank.com.br",
                    CpfCnpj = "09551826620",
                    Nome = "Eduardo Andrade",
                    Endereco = Address.StreetName(),
                    Bairro = Address.StreetSuffix(),
                    Cidade = Address.CitySufix(),
                    Cep = Address.ZipCode(),
                    Uf = Address.UsStateAbbr(),
                    RetornarBase64 = true
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

                result.Message.Should().Be("success");
                result.ResultCode.Should().Be(0);
            }
            catch (Exception)
            {
                Email.EnviarEmail();
                Environment.Exit(0);
            }

        }
    }
}
