using OpenPostLib.Core;

public class Resp
{
    public Resp(HttpResponseMessage response)
    {
        StatusCode = response.StatusCode;
        ReasonPhrase = response.ReasonPhrase ?? string.Empty; // Ensure ReasonPhrase is not null
        Headers = new CustomHeader();
        ContentHeaders = new CustomHeader();
        Content = response.Content;

        foreach (var header in response.Headers)
        {
            Headers.Add(header.Key, header.Value);
        }

        foreach (var header in response.Content.Headers)
        {
            ContentHeaders.Add(header.Key, header.Value);
        }
    }

    public System.Net.HttpStatusCode StatusCode { get; }
    public string ReasonPhrase { get; }
    public CustomHeader Headers { get; }
    public CustomHeader ContentHeaders { get; }
    public HttpContent Content { get; }

    public async Task<string> GetContentAsStringAsync()
    {
        return await Content.ReadAsStringAsync();
    }

    public async Task<byte[]> GetContentAsByteArrayAsync()
    {
        return await Content.ReadAsByteArrayAsync();
    }

    public async Task<Stream> GetContentAsStreamAsync()
    {
        return await Content.ReadAsStreamAsync();
    }

    public Dictionary<string, IEnumerable<string>> GetAllHeaders()
    {
        var headers = new Dictionary<string, IEnumerable<string>>();

        foreach (var header in Headers.Headers)
        {
            headers[header.Key] = header.Value;
        }

        foreach (var header in ContentHeaders.Headers)
        {
            headers[header.Key] = header.Value;
        }

        return headers;
    }
}
