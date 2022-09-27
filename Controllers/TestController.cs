using System.ComponentModel.DataAnnotations;
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
	public IActionResult PostEndpoint(Input input)
	{
		//ModelState.AddModelError("Name", "Is required");
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState); //400 return code
		}

		return Ok(input?.Name);
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

public class Input
{
	[Required]
	[]
	public string Name { get; set; }
}