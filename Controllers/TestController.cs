using Microsoft.AspNetCore.Mvc;

namespace CSharp.Web.API.Controllers;

[Route("api/blah")]
[ApiController]
public class TestController : ControllerBase
{
	[HttpGet]
	public string GetEndpoint()
	{
		return "Hello World";
	}

	[HttpPost]
	public string PostEndpoint()
	{
		return "complete";
	}

	[HttpGet]
	[Route("funny")]
	public string BeFunny()
	{
		return "Fun and games";
	}

	[HttpGet("anotherfunny")]
	public string AnotherFunny()
	{
		return "Fun and games 02";
	}
}