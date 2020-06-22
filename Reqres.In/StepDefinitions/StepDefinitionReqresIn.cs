
using Io.Cucumber.Messages;
using NUnit.Framework;
using Reqres.In.ApiModels;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace Reqres.In.StepDefinitions
{
    [Binding]
    public sealed class StepDefinitionReqresIn
    {
        public ScenarioContext context;
        public ReqresInApiClient _client;

        public StepDefinitionReqresIn(ScenarioContext injectedContext, ReqresInApiClient client){
            context = injectedContext;
            _client = client;

        }

        [Then(@"I get all users from (.*) page\(-s\) via Reqres\.in api")]
        [When(@"I get all users from (.*) page\(-s\) via Reqres\.in api")]

        public void WhenIGetAllUsersViaReqres_InApi(string page)

        {
            int requestPage = string.IsNullOrEmpty(page) ? 0 : (page.Equals("all", StringComparison.InvariantCultureIgnoreCase) ? 0 : int.Parse(page));
            var response = _client.GetUsers(requestPage);
            context.Add(ContextConstans.ApiResponse, response);
        }
        [Then(@"I see that (.*) status code was returned in response")]

        public void ThenISeeThatStatusCodeWasReturnedInResponse(int statusCode)
        {
            var response = context.Get<IRestResponse>(ContextConstans.ApiResponse);
            NUnit.Framework.Assert.AreEqual(statusCode, (int)response.StatusCode, "Status code returned by api is (int)response.StatusCode),but (int statusCode) is expected. ");
        }

        [Then(@"I see that list users from (.*) page was returned in response")]

        public void ThenISeeThatListUsersWasReturnedInResponse(int page)
        {
            var response = context.Get<IRestResponse>(ContextConstans.ApiResponse);
            var usersList = new JsonDeserializer().Deserialize<UsersList>(response);
            CollectionAssert.IsNotEmpty(usersList.data, "users collection is empty,but not empty is expected");
            NUnit.Framework.Assert.AreEqual(page, usersList.page, "Users result page doesn't match expected one");
         }
        /*
        [Given(@"I have created user with (.*) and (.*)")]
        public void GivenIHaveCreatedUserWithAnd(string name, string job)
        {
            var UserData = CreateInstanse<User>; // уточнить
            context.Add(ContextConstans.UserData, UserData);
        }
        [When(@"I create new user prepered via Reqres\.in api")]
        public void WhenICreateNewUserPreperedViaReqres_InApi()
        {
            var user = context.Get<User>(ContextConstans.UserData);
            var response = _client.PostUser(user);
            context.Add(ContextConstans.ApiResponse);
        }
        [Then(@"I see that created user is returned in users list")]
        public void ThenISeeThatCreatedUserIsReturnedInUsersList()
        {
           var response = context.Get<IRestResponse>(ContextConstans.ApiResponse);
            var UsersList = new JsonDeserializer().Deserialize<UsersList>(response).data;
            CollectionAssert.IsNotEmpty(Users , "users collection is empty,but not empty is expected");
            var expectedUser = context.Get<user>(ContextConstans.UserData);
            var foundUser = Users.FirstorDefault(u => u.first_name.Equals(expectedUser.name));
            Assert.IsNotNull(foundUser, "Created user wasn't found on returned list");
        }
        */

    }

}