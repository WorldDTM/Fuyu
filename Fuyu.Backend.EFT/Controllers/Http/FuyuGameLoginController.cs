using System.Threading.Tasks;
using Fuyu.Backend.Common.Models.Requests;
using Fuyu.Backend.Common.Models.Responses;
using Fuyu.Backend.EFT.Networking;
using Fuyu.Backend.EFT.Services;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class FuyuGameLoginController : EftHttpController<FuyuGameLoginRequest>
    {
        public FuyuGameLoginController() : base("/fuyu/game/login")
        {
        }

        public override Task RunAsync(EftHttpContext context, FuyuGameLoginRequest request)
        {
            var sessionId = AccountService.LoginAccount(request.AccountId);
            var response = new FuyuGameLoginResponse()
            {
                SessionId = sessionId
            };

            var text = Json.Stringify(response);
            // NOTE: no need for encryption, request runs internal
            // -- seionmoya, 2024-11-18
            return context.SendJsonAsync(text, false, false);
        }
    }
}