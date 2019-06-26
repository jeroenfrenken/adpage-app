namespace AdPage.Api.Model
{
    public class UserDto
    {
        public string uuid { get; set; }
        
        public string email { get; set; }
        
        public bool enabled { get; set; }
        
        public bool isPremium { get; set; }
    }
}