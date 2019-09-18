using MundiBank_API.Models;
using MundiBank_API.Models_Request;
using MundiBank_API.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Request
{
   public class ConsultSingleCardRequest : BaseRequest<ConsultSingleCard_Response>
    {
        public ConsultSingleCardRequest() :
           base("https://dev.pinbank.com.br/Services/api/Transacoes/ConsultarDadosCartao/")
        {
            this.GetToken();
            this.GetIdCard();

            var obj = new ConsultSingleCard_Request
            {
                Data = new ConsultSingleCard_Request.Root
                {
                    CodigoCanal = 47,
                    CodigoCliente = 7309,
                    CartoaId = this.CartaoId
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

                result.CartaoId = this.CartaoId;
                result.Status = "Ativo";
                result.ResultCode = "0";
                result.Message = "Success";
                result.Bandeira = "MASTERCARD";
                result.NomeImpresso = "teste";
            }
            catch (Exception)
            {
                Email.EnviarEmail();
                Environment.Exit(0);
            }

        }
    }
}
