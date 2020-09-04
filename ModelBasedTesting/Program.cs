using System;
using System.Linq;
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
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter the path and file name for the model");
                return;
            }

            string modelLocation = args[0];

            Browser browser = new Browser();

            Dictionary<string, Type> sharedStates = new Dictionary<string, Type>()
            {
                { "TwitterSharedState", typeof(TwitterSharedState) }
            };

            GraphWalkerClient.load(modelLocation);

            while (GraphWalkerClient.hasNext())
            {
                JObject nextStep = GraphWalkerClient.getNext();

                string className = nextStep.GetValue("modelName").ToString();
                Type modelClass = sharedStates[className];
                ConstructorInfo constructor = modelClass.GetConstructor(new Type[] { typeof(Browser) });

                if (nextStep.GetValue("currentElementName").ToString() != "")
                {
                    Console.WriteLine($"Model and element to be called: {nextStep.GetValue("modelName").ToString()}.{nextStep.GetValue("currentElementName").ToString()}");

                    object instance = constructor.Invoke(new object[] { browser });
                    MethodInfo methodInfo = modelClass.GetMethod(nextStep.GetValue("currentElementName").ToString());
                    methodInfo.Invoke(instance, new object[] { });
                }
            }
        }
    }
}
