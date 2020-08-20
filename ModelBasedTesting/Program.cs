using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;
using ModelBasedTesting.SharedStates;
using ModelBasedTesting.Helpers;

namespace ModelBasedTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            // if (args.Length == 0)
            // {
            //     System.Console.WriteLine("Please enter the path and file name for the model");
            //     return;
            // }

            //run(args[1]);
            run(@"C:\Users\ali.parlakci\Desktop\ModelBasedTesting\ModelBasedTesting\Models.json");

        }
        static void run(string modelLocation)
        {
            Dictionary<string, Type> sharedStates = new Dictionary<string, Type>()
            {
                { "HomeSharedState", typeof(HomeSharedState) },
                { "LoginSharedState", typeof(LoginSharedState) }
            };

            GraphWalkerClient.load(modelLocation);

            while (GraphWalkerClient.hasNext())
            {
                JObject nextStep = GraphWalkerClient.getNext();

                string className = $"{nextStep.GetValue("modelName").ToString()}";
                Type modelClass = sharedStates[className];
                ConstructorInfo constructor = modelClass.GetConstructor(System.Type.EmptyTypes);

                if (nextStep.GetValue("currentElementName") != null)
                {
                    Console.WriteLine($"Model and element to be called: {nextStep.GetValue("modelName").ToString()}.{nextStep.GetValue("currentElementName").ToString()}");

                    object instance = constructor.Invoke(null);

                    MethodInfo methodInfo = modelClass.GetMethod(nextStep.GetValue("currentElementName").ToString());
                    methodInfo.Invoke(instance, new object[] { });
                }
            }
            Browser.GetWebDriver().Quit();
        }
    }
}
