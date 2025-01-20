using OpenPostLib.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPostLib.Core
{
    public static class Query
    {
        public static Resp Execute(Req req)
        {
            if(req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }

            using (HttpClient client = req.ToHttpClient())
            {
                try
                {
                    var requestMessage = req.ToHttpRequestMessage();
                    var response = client.SendAsync(requestMessage).Result;
                    return new Resp(response);
                }
                catch (Exception ex)
                {
                    LLog.LogException(ex);
                    return null;
                }
            }

        }

        public static async Task<Resp> ExecuteAsync(Req req)
        {
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }
            using (HttpClient client = req.ToHttpClient())
            {
                try
                {
                    var requestMessage = req.ToHttpRequestMessage();
                    var response = await client.SendAsync(requestMessage);
                    return new Resp(response);
                }
                catch (Exception ex)
                {
                    LLog.LogException(ex);
                    return null;
                }
            }
        }

        public static string GetContentAsString(Resp response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            return response.GetContentAsStringAsync().Result;
        }

        public static async Task<string> GetContentAsStringAsync(Resp response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            return await response.GetContentAsStringAsync();
        }

        public static byte[] GetContentAsByteArray(Resp response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            return response.GetContentAsByteArrayAsync().Result;
        }

        public static async Task<byte[]> GetContentAsByteArrayAsync(Resp response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            return await response.GetContentAsByteArrayAsync();
        }

    }
}
