This project shows how to use the Lemonway Service in an [ASP.NET Core](https://www.asp.net/core) application.

You can find a more simple example on a Console [.Net core](https://www.microsoft.com/net/core) Application here:
https://github.com/lemonwaysas/csharp-client-directkit-json2

# `LemonWayService` project library

This repository contains the `LemonWayService` project. It is an independent library which you can carry on other projects "as is". 
* You can publish it on nuget if you want.
* It introduces some helpers to make you more comfortable while interacting with our API.

Usage:

```
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

Read the `LwServiceTests.cs` to see how it work

Run them with
```
dotnet test
```

# Development

* VisualStudio 2005 Community edition on Windows