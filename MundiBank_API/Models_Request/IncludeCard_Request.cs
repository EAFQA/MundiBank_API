namespace MundiBank_API.Models_Request
{
    public class IncludeCard_Request
    {
        public Root Data { get; set; }

        public IncludeCard_Request()
        {
            this.Data = new Root();
        }

        public class Root
        {
            public int CodigoCanal { get; set; }
            public int CodigoCliente { get; set; }
            public string Apelido { get; set; }
            public string NomeImpresso { get; set; }
            public string NumeroCartao { get; set; }
            public string DataValidade { get; set; }
            public string CodigoSeguranca { get; set; }
            public bool ValidarCartao { get; set; }
        }
    }
}