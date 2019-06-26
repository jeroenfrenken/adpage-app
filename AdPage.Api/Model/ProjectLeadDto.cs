using System.Collections.Generic;

namespace AdPage.Api.Model
{
    public class ProjectLeadDto
    {
        public string Uuid { get; set; }
        
        public string Ip { get; set; }
        
        public string Posted { get; set; }
        
        public string Display { get; set; }
        
        public string ProjectUuid { get; set; }
        
        public Dictionary<string, string> Data { get; set; }
    }
}