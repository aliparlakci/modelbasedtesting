using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using ModelBasedTesting.SharedStates;
using ModelBasedTesting.Helpers;
using Microsoft.Extensions.Logging;

namespace ModelBasedTesting
{
    class Program
    {
        static int Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter the path and file name for the model");
                return 1;
            }

            return run(args[0]);

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                .Configure<LoggerFilterOptions>(
                    options => options.MinLevel = LogLevel.Information
                );
        }

        static int run(string modelLocation)
        {

            Browser browser = new Browser();

            Dictionary<string, Type> sharedStates = new Dictionary<string, Type>()
            {
                { "TwitterSharedState", typeof(TwitterSharedState) }
            };

            GraphWalkerClient.load(modelLocation);

            while (GraphWalkerClient.hasNext())
            {
                JObject nextStep = GraphWalkerClient.getNext();

                string className = $"{nextStep.GetValue("modelName").ToString()}";
                Type modelClass = sharedStates[className];
                ConstructorInfo constructor = modelClass.GetConstructor(new Type[] { typeof(Browser) });

                if (nextStep.GetValue("currentElementName").ToString() != "")
                {
                    Console.WriteLine($"Model and element to be called: {nextStep.GetValue("modelName").ToString()}.{nextStep.GetValue("currentElementName").ToString()}");

                    object instance = constructor.Invoke(new object[] { browser });

                    MethodInfo methodInfo = modelClass.GetMethod(nextStep.GetValue("currentElementName").ToString());
                    try
                    {
                        methodInfo.Invoke(instance, new object[] { });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"    ERROR: {e.InnerException.Message}");
                        throw e.InnerException;
                        return 1;
                    }
                    finally
                    {
                    }

                }
            }

            return 0;
        }
    }
}
