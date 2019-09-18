using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.DbConnect
{
    public class MongoDB
    {
        public static void Connect()
        {
            var client = new MongoClient("mongodb+srv://eafqafull:<edu12345678>@mundibankapi-p4yn1.azure.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("eafqafull");
        }
    }
}

