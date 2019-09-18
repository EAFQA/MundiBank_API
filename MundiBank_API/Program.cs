using MundiBank_API.Models;
using MundiBank_API.Request;

namespace MundiBank_API
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseRequest<Token_Response> request = new TokenRequest();
            request.Assert();
            BaseRequest<IncludeCard_Response> requestIncludeCard = new IncludeCardRequest();
            requestIncludeCard.Assert();
            BaseRequest<ConsultAllCards_Response> requestAllCards = new ConsultAllCardsRequest();
            requestAllCards.Assert();
            BaseRequest<ConsultSingleCard_Response> requestSingleCard = new ConsultSingleCardRequest();
            requestSingleCard.Assert();
            BaseRequest<Generate_Bullet_Response> requestGenerateBullet = new GenerateBulletRequest();
            requestGenerateBullet.Assert();
            BaseRequest<ExcludeCard_Response> requestExcludeCard = new ExcludeCardRequest();
            requestExcludeCard.Assert();
        }
    }
}
