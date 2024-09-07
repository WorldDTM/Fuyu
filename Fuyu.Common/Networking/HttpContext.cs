using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Fuyu.Common.Compression;
using Fuyu.Common.Serialization;

namespace Fuyu.Common.Networking
{
    public class HttpContext
    {
        public readonly HttpListenerRequest Request;
        public readonly HttpListenerResponse Response;
        public readonly string Path;

        public HttpContext(HttpListenerRequest request, HttpListenerResponse response)
        {
            Request = request;
            Response = response;
            Path = GetPath();
        }

        private string GetPath()
        {
            var path = Request.Url.PathAndQuery;

            if (path.Contains("?"))
            {
                path = path.Split('?')[0];
            }

            return path;
        }

        public Dictionary<string, string> GetPathParameters(HttpController behaviour)
        {
            var result = new Dictionary<string, string>();
            var segments = Path.Split('/');
            var i = 0;

            foreach (var kvp in behaviour.Path)
            {
                if (kvp.Value == EPathSegment.Dynamic)
                {
                    result.Add(kvp.Key, segments[i]);
                }

                ++i;
            }

            return result;
        }

        public bool HasBody()
        {
            return Request.HasEntityBody;
        }

        public byte[] GetBody()
        {
            using (var ms = new MemoryStream())
            {
                Request.InputStream.CopyTo(ms);
                var body = ms.ToArray();

                if (Zlib.IsCompressed(body))
                {
                    body = Zlib.Decompress(body);
                }

                return body;
            }
        }

        public string GetText()
        {
            var body = GetBody();
            return Encoding.UTF8.GetString(body);
        }

        public T GetJson<T>()
        {
            var json = GetText();
            return Json.Parse<T>(json);
        }

        public string GetSessionId()
        {
            return Request.Cookies["PHPSESSID"].Value;
        }
    }
}