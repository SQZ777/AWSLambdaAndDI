using System;

using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace AWSLambdaAndDI
{
    public class Function
    {
        private ITalkService _talkService;
        public Function()
        {
            // Set up Dependency Injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // get talkService instance from DI System
            this._talkService = serviceProvider.GetService<ITalkService>();
        }

        // Use this ctor from unit tests that can mock talkService
        public Function(ITalkService talkService)
        {
            this._talkService = talkService;
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITalkService, TalkService>();
        }


        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return this._talkService.SayHello(input);
        }
    }
}
