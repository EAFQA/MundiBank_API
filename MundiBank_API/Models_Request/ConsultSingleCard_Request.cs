using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Models_Request
{
    public class ConsultSingleCard_Request
    {
        public Root Data { get; set; }

        public ConsultSingleCard_Request()
        {
            this.Data = new Root();
        }

        public class Root
        {
            public int CodigoCanal { get; set; }
            public int CodigoCliente { get; set; }
            public string CartoaId { get; set; }
        }
    }
}
