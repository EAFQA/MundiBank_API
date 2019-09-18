using System;
using System.Collections.Generic;
using System.Text;

namespace MundiBank_API.Utils
{
    public class CardCredit
    {
        public static string NumeroCartaoCredito(int numbers)
        {
            string CreditCardNumber = null;
            int nums = numbers;
            Random num = new Random();
            for (int i = 0; i < nums; i++)
            {
                CreditCardNumber = num.Next(9) + CreditCardNumber;
            }
            return CreditCardNumber;
        }
    }
}
