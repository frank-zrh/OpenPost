using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace OpenPostLib.Core
{
    public class Req
    {
        public HttpMethod Method { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Body { get; set; }
        public string ContentType { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; } = new Dictionary<string, string>();
        public string FilePath { get; set; }
        public List<FormDataItem> FormData { get; set; } = new List<FormDataItem>();
        public Dictionary<string, string> UrlEncodedData { get; set; } = new Dictionary<string, string>();

        public Req(HttpMethod method, string url, string body = "", string contentType = "", string filePath = "")
        {
            Method = method;
            Url = url;
            Body = body;
            ContentType = contentType;
            FilePath = filePath;
        }

        public HttpClient ToHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            if (!string.IsNullOrEmpty(ContentType))
            {
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(ContentType));
            }
            foreach (var header in Headers)
            {
                if (client.DefaultRequestHeaders.Contains(header.Key))
                    client.DefaultRequestHeaders.Remove(header.Key);
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            //set target url
            client.BaseAddress = new Uri(Url);

            //add query parameters
            if (QueryParameters.Count > 0)
            {
                var query = new StringBuilder();
                foreach (var param in QueryParameters)
                {
                    if (query.Length > 0)
                        query.Append("&");
                    query.Append($"{param.Key}={param.Value}");
                }
                client.DefaultRequestHeaders.Add("Query", query.ToString());
            }

            //add method
            client.DefaultRequestHeaders.Add("Method", Method.ToString());

            return client;
        }

        public HttpRequestMessage ToHttpRequestMessage()
        {
            var uriBuilder = new UriBuilder(Url);
            if (QueryParameters.Count > 0)
            {
                var query = new StringBuilder();
                foreach (var param in QueryParameters)
                {
                    if (query.Length > 0)
                        query.Append("&");
                    query.Append($"{param.Key}={param.Value}");
                }
                uriBuilder.Query = query.ToString();
            }

            var request = new HttpRequestMessage(Method, uriBuilder.Uri);

            if (GetContentTypeEnum(ContentType) == ContentTypeEnum.Binary && !string.IsNullOrEmpty(FilePath) && File.Exists(FilePath))
            {              
                request.Content = new StreamContent(new FileStream(FilePath, FileMode.Open, FileAccess.Read));
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                //add filename to header
                request.Content.Headers.Add("FileName", Path.GetFileName(FilePath));
            }
            else if (GetContentTypeEnum(ContentType) == ContentTypeEnum.FormData && FormData.Count > 0)
            {
                var content = new MultipartFormDataContent();
                foreach (var item in FormData)
                {
                    if (item.Type == FormDataItemType.File && File.Exists(item.Value))
                    {
                        //var fileContent = new ByteArrayContent(File.ReadAllBytes(item.Value));
                        //fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                        //{
                        //    Name = item.Key,
                        //    FileName = Path.GetFileName(item.Value)
                        //};
                        //content.Add(fileContent);

                        //use file stream and add filename to header
                        var fileStream = new FileStream(item.Value, FileMode.Open, FileAccess.Read);
                        var fileContent = new StreamContent(fileStream);
                        fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        fileContent.Headers.Add("FileName", Path.GetFileName(item.Value));
                        content.Add(fileContent, item.Key, Path.GetFileName(item.Value));

                    }
                    else
                    {
                        content.Add(new StringContent(item.Value), item.Key);
                    }
                }
                request.Content = content;
            }
            else if (GetContentTypeEnum(ContentType) == ContentTypeEnum.UrlEncoded && UrlEncodedData.Count > 0)
            {
                var content = new FormUrlEncodedContent(UrlEncodedData);
                request.Content = content;
            }
            else if (GetContentTypeEnum(ContentType) == ContentTypeEnum.JavaScript)
            {
                if (!Body.ToLower().StartsWith("{\"script\":"))
                {
                    Body = $"{{\"script\":\"{Body}\"}}";
                }
                request.Content = new StringContent(Body, Encoding.UTF8, GetContentTypeString(ContentTypeEnum.Json));
            }
            else if (!string.IsNullOrEmpty(Body))
            {
                request.Content = new StringContent(Body, Encoding.UTF8, ContentType);
            }

            foreach (var header in Headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return request;
        }

        public void SetContentType(ContentTypeEnum contentType)
        {
            ContentType = GetContentTypeString(contentType);
        }

        public ContentTypeEnum GetContentType()
        {
            return GetContentTypeEnum(ContentType);
        }

        private string GetContentTypeString(ContentTypeEnum contentType)
        {
            return contentType switch
            {
                ContentTypeEnum.Json => "application/json",
                ContentTypeEnum.FormData => "multipart/form-data",
                ContentTypeEnum.UrlEncoded => "application/x-www-form-urlencoded",
                ContentTypeEnum.JavaScript => "application/javascript",
                ContentTypeEnum.Xml => "application/xml",
                ContentTypeEnum.Html => "text/html",
                ContentTypeEnum.Text => "text/plain",
                ContentTypeEnum.Binary => "application/octet-stream",
                ContentTypeEnum.None => string.Empty,
                _ => "application/json",
            };
        }

      
        public static ContentTypeEnum GetContentTypeEnum(string contentType)
        {
            return contentType.ToLower() switch
            {
                "application/json" => ContentTypeEnum.Json,
                "multipart/form-data" => ContentTypeEnum.FormData,
                "application/x-www-form-urlencoded" => ContentTypeEnum.UrlEncoded,
                "application/javascript" => ContentTypeEnum.JavaScript,
                "application/xml" => ContentTypeEnum.Xml,
                "text/html" => ContentTypeEnum.Html,
                "text/plain" => ContentTypeEnum.Text,
                "application/octet-stream" => ContentTypeEnum.Binary,
                _ => ContentTypeEnum.None,
            };
        }

        public enum ContentTypeEnum
        {
            Json,
            FormData,
            UrlEncoded,
            JavaScript,
            Xml,
            Html,
            Text,
            Binary,
            None
        }

        public class FormDataItem
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public FormDataItemType Type { get; set; }
        }

        public enum FormDataItemType
        {
            String,
            File
        }
    }
}

