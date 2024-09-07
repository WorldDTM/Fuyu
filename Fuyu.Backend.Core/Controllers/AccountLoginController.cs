using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Core.Services;

namespace Fuyu.Backend.Core.Controllers
{
    public class AccountLoginController : HttpController
    {
        public AccountLoginController() : base("/account/login")
        {
        }

        public override void Run(HttpContext context)
        {
            var request = context.GetJson<AccountLoginRequest>();
            var result = AccountService.LoginAccount(request.Username, request.Password);
            var response = new AccountLoginResponse()
            {
                SessionId = result
            };

            SendJson(context, Json.Stringify(response));
        }
    }
}