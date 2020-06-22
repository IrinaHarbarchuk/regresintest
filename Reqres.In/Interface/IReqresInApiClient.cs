using Reqres.In.ApiModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow.CommonModels;

namespace Reqres.In
{
    public interface IReqresInApiClient
    {
        IRestResponse GetUsers(int page);
        IRestResponse PostUser(CreateUser user);
      //  void PutUser();
      //  void PutchUser();
      //  void DeleteUser();

    }
}
