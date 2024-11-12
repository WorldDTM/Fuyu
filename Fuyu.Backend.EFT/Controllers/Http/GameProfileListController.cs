using System.Threading.Tasks;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.BSG.Models.Profiles;
using Fuyu.Backend.BSG.Models.Responses;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class GameProfileListController : HttpController
    {
        public GameProfileListController() : base("/client/game/profile/list")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var sessionId = context.GetSessionId();
            var profile = EftOrm.GetActiveProfile(sessionId);
            Profile[] profiles;

            if (profile.ShouldWipe)
            {
                profiles = [];
            }
            else
            {
                profiles = [profile.Pmc, profile.Savage];
            }

            var response = new ResponseBody<Profile[]>()
            {
                data = profiles
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}