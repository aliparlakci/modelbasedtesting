using System;
using System.IO;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ModelBasedTesting
{
    static class GraphWalkerClient
    {
        private static RestClient client = new RestClient();
        private static RestRequest requestHasNext = new RestRequest("hasNext", Method.GET);
        private static RestRequest requestGetNext = new RestRequest("getNext", Method.GET);
        private static RestRequest requestGetData = new RestRequest("getData", Method.GET);
        private static RestRequest requestLoad = new RestRequest("load", Method.POST);
        private static RestRequest requestGetStatistics = new RestRequest("getStatistics", Method.GET);

        static GraphWalkerClient()
        {
            client.BaseUrl = new Uri("http://localhost:8887/graphwalker/");
            foreach (RestRequest request in new RestRequest[] { requestGetData, requestGetNext, requestHasNext, requestGetStatistics, requestLoad })
            {
                request.AddHeader("Accept", "text/plain");
            }
        }

        public static bool hasNext()
        {
            IRestResponse restResponse = client.Execute(requestHasNext);
            checkError(restResponse);

            JObject jsonResponse = JObject.Parse(restResponse.Content);
            return jsonResponse.GetValue("result").ToString().Equals("ok") || jsonResponse.GetValue("hasNext").ToString().Equals("true");
        }

        public static JObject getNext()
        {
            IRestResponse restResponse = client.Execute(requestGetNext);
            checkError(restResponse);
            return JObject.Parse(restResponse.Content);
        }

        public static JObject getData()
        {
            IRestResponse restResponse = client.Execute(requestGetData);
            JObject jsonResponse = JObject.Parse(restResponse.Content);
            return JObject.Parse(jsonResponse.GetValue("data").DeepClone().ToString());
        }

        public static void setData(string dataToSend)
        {
            // The request has to be built uniquely for every call, otherwise
            // the AddParameter will be the same for every call.
            RestRequest requestSetData = new RestRequest("setData/{script}", Method.PUT);
            requestSetData.AddHeader("Accept", "text/plain");
            requestSetData.AddHeader("Content-Type", "text/plain");
            requestSetData.AddParameter("script", dataToSend, ParameterType.UrlSegment);
            IRestResponse restResponse = client.Execute(requestSetData);
            checkError(restResponse);
        }

        public static void load(string modelLocation)
        {
            string model = File.ReadAllText(modelLocation);
            requestLoad.AddHeader("Content-Type", "text/plain");
            requestLoad.AddParameter("text/plain", model, ParameterType.RequestBody);
        }

        public static string getStatistics()
        {
            IRestResponse restResponse = client.Execute(requestGetStatistics);
            checkError(restResponse);
            return restResponse.Content.ToString();

        }

        public static void checkError(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                const string MESSAGE = "Error while retrieving the response.";
                throw new Exception(MESSAGE, response.ErrorException);
            }

            int numericStatusCode = (int)response.StatusCode;
            if (numericStatusCode != 200)
            {
                const string MESSAGE = "Error while retrieving the response.";
                throw new Exception($"{MESSAGE} Server responded with {numericStatusCode}");
            }

            JObject jsonResponse = JObject.Parse(response.Content);
            if (!jsonResponse.GetValue("result").ToString().Equals("ok"))
            {
                const string MESSAGE = "REST call failed.";
                throw new Exception(MESSAGE);
            }
        }
    }
}