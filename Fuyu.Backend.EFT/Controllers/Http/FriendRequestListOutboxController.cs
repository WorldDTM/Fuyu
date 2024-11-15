using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class FriendRequestListOutboxController : HttpController
    {
        public FriendRequestListOutboxController() : base("/client/friend/request/list/outbox")
        {
        }

        public override Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<object[]>()
            {
                data = []
            };

            return context.SendJsonAsync(Json.Stringify(response));
        }
    }
}