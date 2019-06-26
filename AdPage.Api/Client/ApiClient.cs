namespace AdPage.Api.Client
{

    public sealed class ApiClient
    {

        private static BaseClient _instance = null;
        private static readonly object _padlock = new object();

        public static BaseClient Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new BaseClient();
                    }
                    return _instance;
                }
            }
        }

    }
    
}