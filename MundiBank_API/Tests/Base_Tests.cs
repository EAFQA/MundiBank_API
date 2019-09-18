using FluentAssertions;
using MundiBank_API.Models;
using MundiBank_API.Request;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MundiBank_API.Tests
{

    public class Base_Tests
    {
        public string token;

        public void CreateTokenRest()
        {
            var createToken = new RestClient("https://dev.pinbank.com.br/Services/api/token");
            var requestPost = new RestRequest(Method.POST);

            requestPost.AddHeader("Postman-Token", "a614b16f-82a6-48fd-b9d0-2840cbd10bdc");
            requestPost.AddHeader("cache-control", "no-cache");
            requestPost.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            requestPost.AddHeader("Accept", "application/json");
            requestPost.AddParameter("undefined", "grant_type=password&username=Yj3b0CsopkBR&password=umo1LNtje0Edx1Xv", ParameterType.RequestBody);

            IRestResponse response = createToken.Execute(requestPost);
           var token = response.Content.ToString();
            var responseObject = JsonConvert.DeserializeObject<Token_Response>(response.Content);
            token = responseObject.access_token.Should().Be(responseObject.access_token).ToString();

            int statusCode = (int)response.StatusCode;
            response.StatusCode.Should().Be(200);
        }

        public static void includeCardRest()
        {
            var includeCard = new RestClient("https://dev.pinbank.com.br/Services/api/Transacoes/IncluirCartao");
            var requestPost = new RestRequest(Method.POST);
            requestPost.AddJsonBody("{\n  \"Data\": {\n    \"CodigoCanal\": 47,\n    \"CodigoCliente\": 7309,\n    \"Apelido\": \"Lisa Farr\",\n    \"NomeImpresso\": \"Lisa Farr\",\n    \"NumeroCartao\": \"5193330849628547\",\n    \"DataValidade\": \"202208\",\n    \"CodigoSeguranca\": \"632\",\n    \"ValidarCartao\": false\n  }\n}");
        }

        public static void consultAllCards()
        {
            var consultAllCards = new RestClient("https://dev.pinbank.com.br/Services/api/Transacoes/ConsultarCartoes");
            var requestPost = new RestRequest(Method.POST);
        }

        public static void consultSingleCard()
        {
            var consultSingleCard = new RestClient("https://dev.pinbank.com.br/Services/api/Transacoes/ConsultarDadosCartao/");
            var requestPost = new RestRequest(Method.POST);
        }

        public static void generateBullet()
        {
            var generateBullet = new RestClient("https://dev.pinbank.com.br/Services/api/CashIn/GerarBoleto");
            var requestPost = new RestRequest(Method.POST);
        }

        public static void makeTransaction()
        {
            var makeTransaction = new RestClient("https://dev.pinbank.com.br/Services/api/Transacoes/EfetuarTransacao");
            var requestPost = new RestRequest(Method.POST);
        }

        public static void excludeCard()
        {
            var excludeCard = new RestClient("https://dev.pinbank.com.br/Services/api/Transacoes/ExcluirCartao");
            var requestPost = new RestRequest(Method.POST);
        }
    }
}
