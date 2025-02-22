using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fuyu.Backend.BSG.Models.Responses;
using Fuyu.Backend.EFT.Networking;
using Fuyu.Backend.EFT.Services;

namespace Fuyu.Backend.EFT.Controllers.Http
{
    public partial class LocaleController : EftHttpController
    {
        [GeneratedRegex("^/client/locale/(?<languageId>[a-z]+(-[a-z]+)?)$")]
        private static partial Regex PathExpression();

        public LocaleController() : base(PathExpression())
        {
        }

        public override Task RunAsync(EftHttpContext context)
        {
            var parameters = context.GetPathParameters(this);

            var languageId = parameters["languageId"];
            var locale = EftOrm.GetGlobalLocale(languageId);
            var response = new ResponseBody<Dictionary<string, string>>
            {
                data = locale
            };

            return ETagService.SendCachedAsync(context, response);
        }
    }
}
