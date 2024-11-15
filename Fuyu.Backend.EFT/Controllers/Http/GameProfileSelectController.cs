using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class GameProfileSelectController : HttpController
    {
        public GameProfileSelectController() : base("/client/game/profile/select")
        {
        }

        public override Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<ProfileSelectResponse>()
            {
                data = new ProfileSelectResponse()
                {
                    status = "ok"
                }
            };

            return context.SendJsonAsync(Json.Stringify(response));
        }
    }
}