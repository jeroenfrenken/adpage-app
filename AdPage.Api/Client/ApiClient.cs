using System;
using AdPage.Api.Configuration;
using AdPage.Api.Model;

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
                        var config = new ApiConfiguration();
                        config.url = "https://app.fastpages.io/api";
                        config.apiKey =
                            "lTsJlhD9sJ1J43xxPz8zZG9THyNMqR98nmiA7viR6wwcGfqdVsVdLUkBot5t2QeLLcKxUgsavURm82Ka9psp5LNo4sOmd9zWjEAC0V1y4gJ64FgflLOjWUbWYgwTWSJT";
                        _instance = new BaseClient();
                        _instance.Init(config);
                    }
                    return _instance;
                }
            }
        }

    }
    
}