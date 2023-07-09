## __One Time Password project - description__

Create an API which will generate a 6-digit __Password__ valid for only 30 seconds. After 30 seconds will generate a new one. The input for the API will be an __User ID__ and __Time of the request__, and it will return the __password__ for that User. If there are multiple requests with the same __User ID__ within 30 seconds the __password__ will be the same.  
Create a basic client application with a simple UI that uses the API and displays the password and the number of seconds after will expire.

### Task requirements:
* Layered Architecture
* Dependency injection
* Clean code
* add Unit Tests for the logic
* data can be stored in memory

---

## Technical details:
__API project__
* Name: OneTimePassword.API
* .Net 6 - Web API
* Visual Studio 2022

__Client App project__
* Name: OneTimePassword.ClientApp
* Angular v.15
* Node 18.14.1
* Angular CLI 15.1.6
* npm 9.3.1