using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenPostLib.Core
{
    public class RequestInfo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public Req RequestParameters { get; set; }      
        
        public DeletedStastus status { get; set; } = DeletedStastus.Active;
    }

    public class Group
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public List<RequestInfo> HttpRequests { get; set; } = new List<RequestInfo>();
        public DeletedStastus status { get; set; } = DeletedStastus.Active;
    }

    public class Project
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public List<Group> Groups { get; set; } = new List<Group>();
        public DeletedStastus status { get; set; } = DeletedStastus.Active;
    }

    public enum DeletedStastus
    {
        Active,
        Deleted
    }

}
