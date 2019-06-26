using System.Collections.Generic;

namespace AdPage.Api.Model
{
    public class ProjectDto
    {
        public string uuid { get; set; }
        
        public string name { get; set; }
        
        public bool published { get; set; }
        
        public List<ProjectDomainDto> domains { get; set; }
    }
}