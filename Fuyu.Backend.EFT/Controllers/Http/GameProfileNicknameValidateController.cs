using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Requests;
using Fuyu.Backend.BSG.Models.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class GameProfileNicknameValidateController : HttpController<GameProfileNicknameValidateRequest>
    {
        public GameProfileNicknameValidateController() : base("/client/game/profile/nickname/validate")
        {
        }

        public override Task RunAsync(HttpContext context, GameProfileNicknameValidateRequest request)
        {
            // TODO:
            // * validate nickname usage
            // -- seionmoya, 2024/08/28

            var response = new ResponseBody<GameProfileNicknameValidateResponse>()
            {
                data = new GameProfileNicknameValidateResponse()
                {
                    status = "ok"
                }
            };

            return context.SendJsonAsync(Json.Stringify(response));
        }
    }
}