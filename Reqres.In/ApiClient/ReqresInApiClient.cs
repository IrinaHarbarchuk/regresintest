using Reqres.In.ApiModels;
using RestSharp;
using System;
using System.Configuration;
using TechTalk.SpecFlow.CommonModels;

namespace Reqres.In
{
    public class ReqresInApiClient : IReqresInApiClient
    {
        public readonly RestClient Client;
        public ReqresInApiClient()         
            {
                Client = Client ?? new RestClient();
                Client.BaseUrl = new Uri(ConfigurationManager.AppSettings.Get("ReqresInBaseUrl"));
            }
        

        public IRestResponse GetUsers(int page)
        {
            string resours = page==default(int) ? ($"users") : ($"users?page=(page)");
            IRestRequest req = new RestRequest(resours);
            var response = Client.Get(req);
            return response;
        }


        public IRestResponse PostUser(CreateUser user) //уточнить
        {
            IRestRequest req = new RestRequest("users");
     
            req.AddJsonBody(user);
            var response = Client.Post(req);
            return response;
        }
        public void DeleteUser()
        {
           // throw new NotImplementedException();
        }

        public void PutchUser()
        {
          //  throw new NotImplementedException();
        }

        public void PutUser()
        {
          //  throw new NotImplementedException();
        }

    }

}
