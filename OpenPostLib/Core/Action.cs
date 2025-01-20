using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using OpenPostLib.Log;

namespace OpenPostLib.Core
{
    public class Action : Node
    {
        public List<Project> RefProjects { get; set; }
        public Guid RequestId { get; set; }
        public Resp? Response { get; set; }
        
        private Req? _request;
        public object? NextAction { get; set; }
        public object? ParentAction { get; set; }

        public Action(List<Project> refProjects, Guid requestId)
        {
            RefProjects = refProjects;
            RequestId = requestId;
            FindRequest();
            Response = default;
        }

        // Get a request from a list of projects by GUID
        private void FindRequest()
        {
            if (_request == null)
            {
                foreach (var project in RefProjects)
                {
                    foreach (var group in project.Groups)
                    {
                        foreach (var requestInfo in group.HttpRequests)
                        {
                            if (requestInfo.Id == RequestId)
                            {
                                _request = requestInfo.RequestParameters;
                            }
                        }
                    }
                }
            }
        }

        public async Task<Resp> ExecuteAsync()
        {
            try
            {
                if (_request == null)
                {
                    throw new InvalidOperationException("Request cannot be null.");
                }

                using (HttpClient client = _request.ToHttpClient())
                {
                    var requestMessage = _request.ToHttpRequestMessage();
                    var httpResponse = await client.SendAsync(requestMessage);
                    var response = new Resp(httpResponse);
                    return response;
                }
            }
            catch (Exception ex)
            {
                LLog.LogException(ex);
                throw;
            }
        }

        public async Task<string> ExecuteAsStringAsync()
        {
            try
            {
                var response = await ExecuteAsync();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                LLog.LogException(ex);
                throw;
            }
        }

        public async Task<byte[]> ExecuteAsByteArrayAsync()
        {
            try
            {
                var response = await ExecuteAsync();
                return await response.Content.ReadAsByteArrayAsync();
            }
            catch (Exception ex)
            {
                LLog.LogException(ex);
                throw;
            }
        }

        public async Task<Stream> ExecuteAsStreamAsync()
        {
            try
            {
                var response = await ExecuteAsync();
                return await response.Content.ReadAsStreamAsync();
            }
            catch (Exception ex)
            {
                LLog.LogException(ex);
                throw;
            }
        }

        public override Node? Route(string key)
        {
            // Custom routing logic for Action
            return base.Route(key);
        }
    }
}