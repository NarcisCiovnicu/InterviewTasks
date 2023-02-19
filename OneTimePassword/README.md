## __One Time Password project - description__

Create an API which will give you a One Time Password based on an User Id and the time of request, which will only last for 30 seconds. After 30 seconds generate a new one.

Create a basic client application with a simple UI that uses the API and displays the password and the number of seconds after will expire.

### Task requirements:
* Layered Architecture
* Dependency injection
* Clean code
* add Unit tests for Logic layer
* no need for a Database, data can be stored in memory

## Technical details:
__API project__
* Project Name: OneTimePassword.API
* .Net 6 - Web API
* Visual Studio 2022

__Client App project__
* Project Name: OneTimePassword.ClientApp
* Angular v.15
* Node 18.14.1
* Angular CLI 15.1.6
* npm 9.3.1