Feature: UsersFeature
	In order to avoid errors with Reqres.in users api

@regression @Reqres.in @GetRequest @ListUsers @API
Scenario: 'Get all users'from 2 page api call with valid request returns list users
	When I get all users from 2 page(-s) via Reqres.in api
	Then I see that 200 status code was returned in response
	And I see that list users from 2 page was returned in response

@regression @Reqres.in @PostRequest @API
Scenario: I can create new user on reqres.in api
Given I have created user with <name> and <job>
When I create new user prepered via Reqres.in api
Then I see that 201 status code was returned in response
And I get all  users from all page(-s) was returned in response
And I see that created user is returned in users list




