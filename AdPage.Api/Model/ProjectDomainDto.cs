using System;
using System.Collections.Generic;

namespace AdPage.Api.Model
{
    public class ProjectDomainDto
    {
        public string doamin { get; set; }
        
        public bool verified { get; set; }
        
        public List<string> links { get; set; }
    }
}