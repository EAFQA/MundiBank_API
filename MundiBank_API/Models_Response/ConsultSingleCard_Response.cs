using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Models
{
    public class ConsultSingleCard_Response
    {
        public string Apelido { get; set; }
        public string DataValidade { get; set; }
        public string Bandeira { get; set; }
        public string Status { get; set; }
        public string CartaoId { get; set; }
        public string NomeImpresso { get; set; }
        public string NumeroCartao { get; set; }
        public string ResultCode { get; set; }
        public string Message { get; set; }
    }
}
