This project shows how to use the Lemonway Service in an [ASP.NET Core](https://www.asp.net/core) application.

You can find a more simple exemple on a Console [.Net core](https://www.microsoft.com/net/core) Application here:

https://github.com/lemonwaysas/csharp-client-directkit-json2

# `LemonWayService` project library

The `LemonWayService` is an independent library which you can carry on other projects "as is". 
* It introduces some helpers to make you more comfortable while interacting with our API.
* You can publish it on nuget if you want.

Usage:

```csharp
// create a service (you usually do it only once)
ILwService service = new LwService("https://sandbox-api.lemonway.fr/mb/demo/dev/directkitjson2/Service.asmx");

// create a request factory
var factory = new LwRequestFactory(new LwConfig
	{
		Login = "society",
		Password = "123456",
		Language = "en",
		Version = "4.0"
	},
	//you can also give an IEndUserInfoProvider instead
	new EndUserInfo 
	{
		IP = "127.0.0.1",
		UserAgent = "xunit"
	});


// init the request 
var request = factory.CreateRequest();

// send it and get the response
var response = service.Call("GetWalletDetails", request.Set("wallet", "sc"));

// access to different data in the response
Assert.Equal("sc", response.d["WALLET"]["ID"].ToString());

```
Remark: You can mock our service by stubing or fake implementing the `ILwService` interface.

# Run test case

Read the `LwServiceTests.cs` to see how it work, you should see the same code as above

Run them with
```
cd test/LemonWayService.Tests
dotnet test
```

# How to integrate the `LemonWayService` project to the ASP.NET application

This commit show all the changes on the ASP.NET application in order to call a [`GetWalletDetails` function](http://documentation.lemonway.fr/api-en/directkit/manage-wallets/getwalletdetails-getting-detailed-wallet-data)
in a Controller.
https://github.com/lemonwaysas/aspdotnet-client-directkit-json2/commit/372c49a0b88f50616661f21743bd6ad0dbe55488

In resume:
* The LemonWay Service is configured in the `appsettings.json` (section `LemonWay`).
* The service is register as a Singleton in the default DI Container (`Startup.cs`).
* Other configuration is passe to Controllers through the OptionsService.
* The `IEndUserInfoProvider` is implemented using the HttpContext to extract EndUser IP, and UserAgent.
* The `LwRequestFactory` has not been used, because it is not neccessary.

It is only one way to do get thing done. You might come up with many other way. You might not use  `LemonWayService` library but make other one.


# Development

* VisualStudio 2005 Community edition on Windows