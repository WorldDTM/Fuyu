using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.Models.Responses;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class FriendRequestListOutboxController : HttpController
    {
        public FriendRequestListOutboxController() : base("/client/friend/request/list/outbox")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<object[]>()
            {
                data = []
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}