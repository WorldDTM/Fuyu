using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Responses;
using Fuyu.Backend.BSG.Models.Servers;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public class GameConfigController : HttpController
    {
        public GameConfigController() : base("/client/game/config")
        {
        }

        public override async Task RunAsync(HttpContext context)
        {
            var response = new ResponseBody<GameConfigResponse>
            {
                data = new GameConfigResponse()
                {
                    backend = new Backends()
                    {
                        Lobby       = "http://localhost:8010",
                        Trading     = "http://localhost:8010",
                        Messaging   = "http://localhost:8010",
                        Main        = "http://localhost:8010",
                        RagFair     = "http://localhost:8010"
                    },
                    utc_time = 1724450891.010541,
                    reportAvailable = true,
                    purchasedGames = new PurchasedGames()
                    {
                        eft = true,
                        arena = true
                    },
                    isGameSynced = true
                }
            };

            await context.SendJsonAsync(Json.Stringify(response));
        }
    }
}