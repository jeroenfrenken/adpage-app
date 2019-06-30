namespace AdPage.Api.Client
{

    public sealed class ApiClient
    {

        private static BaseClient _instance;
        private static readonly object PadLock = new object();

        /*
         * Hold a instance of the BaseClient in a static context for easy access in the application
         */
        public static BaseClient Instance
        {
            get
            {
                lock (PadLock)
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