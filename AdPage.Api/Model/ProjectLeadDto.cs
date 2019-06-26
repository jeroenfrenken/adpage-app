using System.Collections.Generic;

namespace AdPage.Api.Model
{
    public class ProjectLeadDto
    {
        public List<ProjectLeadFieldDto> fields { get; set; }
        
        public List<KeyValuePair<string, string>> data { get; set; }
    }
}