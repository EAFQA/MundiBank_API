using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Models_Request
{
    public class ConsultAllCards_Request
    {
        public Root Data { get; set; }

        public ConsultAllCards_Request()
        {
            this.Data = new Root();
        }

        public class Root
        {
            public int CodigoCanal { get; set; }
            public int CodigoCliente { get; set; }
            public string StatusCartao { get; set; }
        }
    }
}
