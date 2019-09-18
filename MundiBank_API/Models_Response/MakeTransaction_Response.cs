using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Models
{
   public class MakeTransaction_Response
    {
        public int CodigoAutorizacao { get; set; }
        public int NsuOperacao { get; set; }
        public int ResultCode { get; set; }
        public int Message { get; set; }
    }
}
