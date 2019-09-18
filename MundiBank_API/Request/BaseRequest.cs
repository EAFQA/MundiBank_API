using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace MundiBank_API.Request
{
    public abstract class BaseRequest<TResult> where TResult : class
    {
        private string Uri { get; }
        private IRestClient Client { get; set; }
        private IRestRequest Request { get; set; }
        private IRestResponse Response { get; set; }
        protected string Token { get; set; }
        protected string CartaoId { get; set; }
        protected string ConsultAllCard { get; set; }
        protected IDictionary<string, string> Parameters;
        protected IDictionary<string, string> Headers;
        protected TResult Result { get; set; }

        public BaseRequest(string uri)
        {
            this.Uri = uri;
            this.Client = new RestClient(uri);
            this.Request = new RestRequest(Method.POST);
            this.Parameters = new Dictionary<string, string>();
            this.Headers = new Dictionary<string, string>();
        }

        protected void GetToken()
        {
            this.Token = new TokenRequest().Result.access_token;
        }

        protected void GetIdCard()
        {
            this.CartaoId = new IncludeCardRequest().Result.Data.CartaoId;
        }

        public void Configure(object obj = null)
        {
            this.ConfigureHeader();
            this.ConfigureParameter();
            this.ConfigureBody(obj);
        }

        private void ConfigureHeader()
        {
            foreach (var item in this.Headers)
            {
                this.Request.AddHeader(item.Key, item.Value);
            }
        }

        private void ConfigureParameter()
        {
            foreach (var item in this.Parameters)
            {
                this.Request.AddParameter(item.Key, item.Value, ParameterType.RequestBody);
            }
        }

        private void ConfigureBody(object obj)
        {
            this.Request.AddJsonBody(obj);
        }

        public void Send()
        {
            this.Response = this.Client.Execute(this.Request);
            this.DeserializeResponse();
        }

        public abstract void Assert();

        public void DeserializeResponse()
        {
            this.Result = JsonConvert.DeserializeObject<TResult>(this.Response.Content);
        }
    }
}