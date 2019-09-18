namespace MundiBank_API.Models
{
    public class IncludeCard_Response
    {
        public Root Data { get; set; }

        public IncludeCard_Response()
        {
            this.Data = new Root();
        }

        public class Root
        {
            public string CartaoId { get; set; }
        }
        public bool ResultCode { get; set; }
        public string Message { get; set; }
    }
}
