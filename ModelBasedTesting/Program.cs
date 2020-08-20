using System;
using System.Reflection;
using Newtonsoft.Json.Linq;
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

            string modelLocation = args[1];
            GraphWalkerClient.load(modelLocation);

            // As long as we have elemnts from GraphWalkers path generation
            // to fetch, we'll continue 
            while (GraphWalkerClient.hasNext())
            {
                // Get the next element name from GraphWalker.
                // The element might either be an edge or a vertex.
                JObject nextStep = GraphWalkerClient.getNext();

                // Create a mapping from the model name to an actual class.
                Type modelClass = Type.GetType($"{nextStep.GetValue("modelName").ToString()}");
                ConstructorInfo constructor = modelClass.GetConstructor(System.Type.EmptyTypes);

                // Invoke a method to call. If the currentElementName is null,
                // it means that it's an edge with no name. In practicality, this is a noop, a no operation.
                // No method to call, so we should move on to next step.
                if (nextStep.GetValue("currentElementName").ToString() != "")
                {
                    Console.WriteLine($"Model and element to be called: {nextStep.GetValue("modelName").ToString()}.{nextStep.GetValue("currentElementName").ToString()}");

                    object instance = constructor.Invoke(null);

                    // Create a mapping from the element name to an actual method.
                    MethodInfo methodInfo = modelClass.GetMethod(nextStep.GetValue("currentElementName").ToString());
                    methodInfo.Invoke(instance, new object[] { });
                }
            }
        }
    }
}
