using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Models
{
    public class Generate_Bullet_Response
    {
        public int NossoNumero { get; set; }
        public int LinhaDigitavel { get; set; }
        public int Base64 { get; set; }
        public int ResultCode { get; set; }
        public string Message { get; set; }
    }
}
