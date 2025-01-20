using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenPostLib.Core
{
    public class Solution
    {
        public List<Project> Projects { get; set; }
        public List<Flow> Flows { get; set; }

        public Solution()
        {
            Projects = new List<Project>();
            Flows = new List<Flow>();
        }

        public void ExportToFile(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (var stream = File.Create(filePath))
            {
                JsonSerializer.Serialize(stream, this, options);
            }
        }

        public Solution ImportFromFile(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                var solutiondata = JsonSerializer.Deserialize<Solution>(stream) ?? new Solution();

                return solutiondata;
            }
        }

        public void GenerateSampleData()
        {
            Projects = GenSampleData();
        }

        private List<Project> GenSampleData()
        {
            var projects = new List<Project>();

            var project = new Project
            {
                Name = "Sample Project",
                Description = "This is a sample project",
                Order = 1,
                Groups = new List<Group>()
            };

            // Group 1: Public Websites
            var websiteGroup = new Group
            {
                Name = "Public Websites Group",
                Description = "Group for visiting public websites",
                Order = 1,
                HttpRequests = new List<RequestInfo>()
            };

            var websiteRequests = new List<(string Name, string Url)>
    {
        ("Visit Bing", "https://bing.com"),
        ("Visit Microsoft", "https://www.microsoft.com")
    };

            for (int k = 0; k < websiteRequests.Count; k++)
            {
                var (name, url) = websiteRequests[k];

                var requestParameters = new Req(HttpMethod.Get, url)
                {
                    Headers = new Dictionary<string, string>
            {
                { "Accept", "text/html" }
            }
                };

                var request = new RequestInfo
                {
                    Name = name,
                    Description = $"GET request to {name}",
                    Order = k + 1,
                    RequestParameters = requestParameters
                };

                websiteGroup.HttpRequests.Add(request);
            }

            project.Groups.Add(websiteGroup);

            // Group 2: Public Web API
            var apiGroup = new Group
            {
                Name = "Public Web API Group",
                Description = "Group for interacting with a public web API",
                Order = 2,
                HttpRequests = new List<RequestInfo>()
            };

            var apiRequests = new List<(HttpMethod Method, string Name, string Url, string Body)>
    {
        (HttpMethod.Get, "Get Data", "https://jsonplaceholder.typicode.com/posts/1", ""),
        (HttpMethod.Post, "Create Data", "https://jsonplaceholder.typicode.com/posts", JsonSerializer.Serialize(new { title = "foo", body = "bar", userId = 1 })),
        (HttpMethod.Put, "Update Data", "https://jsonplaceholder.typicode.com/posts/1", JsonSerializer.Serialize(new { id = 1, title = "foo", body = "bar", userId = 1 })),
        (HttpMethod.Delete, "Delete Data", "https://jsonplaceholder.typicode.com/posts/1", "")
    };

            for (int k = 0; k < apiRequests.Count; k++)
            {
                var (method, name, url, body) = apiRequests[k];

                var requestParameters = new Req(method, url, body)
                {
                    Headers = new Dictionary<string, string>
            {
                { "Accept", "application/json" },
               
            }
                };

                var request = new RequestInfo
                {
                    Name = name,
                    Description = $"{method} request to {name}",
                    Order = k + 1,
                    RequestParameters = requestParameters
                };

                apiGroup.HttpRequests.Add(request);
            }

            project.Groups.Add(apiGroup);

            projects.Add(project);

            return projects;
        }




    }
}