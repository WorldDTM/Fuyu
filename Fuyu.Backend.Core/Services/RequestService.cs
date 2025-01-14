using System;
using System.Text;
using Fuyu.Backend.Common.Models.Requests;
using Fuyu.Backend.Common.Models.Responses;
using Fuyu.Common.Collections;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Core.Services
{
    public static class RequestService
    {
        private static ThreadDictionary<string, HttpClient> _httpClients;

        static RequestService()
        {
            _httpClients = new ThreadDictionary<string, HttpClient>();

            // TODO:
            // * get address from config
            // -- seionmoya, 2024/09/08
            _httpClients.Set("eft", new HttpClient("http://localhost:8010"));
            _httpClients.Set("arena", new HttpClient("http://localhost:8020"));
        }

        private static T2 HttpPost<T1, T2>(string id, string path, T1 request)
        {
            if (!_httpClients.TryGet(id, out var httpc))
            {
                throw new Exception($"Id '{id}' not found");
            }

            var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            var response = httpc.Post(path, requestBytes);
            var responseJson = Encoding.UTF8.GetString(response.Body);
            var responseValue = Json.Parse<T2>(responseJson);

            return responseValue;
        }

        public static int RegisterGame(string game, string username, string edition)
        {
            var request = new FuyuGameRegisterRequest()
            {
                Username = username,
                Edition = edition
            };
            var response = HttpPost<FuyuGameRegisterRequest, FuyuGameRegisterResponse>(
                game,
                "/fuyu/game/register",
                request);

            return response.AccountId;
        }
    }
}
