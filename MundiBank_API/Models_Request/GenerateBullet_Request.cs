using System;

namespace MundiBank_API.Models_Request
{
    public class GenerateBullet_Request
    {
        public Root Data { get; set; }

        public GenerateBullet_Request()
        {
            this.Data = new Root();
        }

        public class Root
        {
            public int CodigoCanal { get; set; }
            public int CodigoCliente { get; set; }
            public string DataVencimento { get; set; }
            public int Valor { get; set; }
            public string Email { get; set; }
            public string DadosSacado { get; set; }
            public string CpfCnpj { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Cep { get; set; }
            public string Uf { get; set; }
            public bool RetornarBase64 { get; set; }
            public int DdiTerceiro { get; set; }
            public int DddTerceiro { get; set; }
            public int NumeroCelularTerceiro { get; set; }
        }
    }
}
