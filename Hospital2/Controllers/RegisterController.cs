using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers;
public class RegisterController : Controller
{
	private readonly ILogger<RegisterController> _logger;

	public RegisterController(ILogger<RegisterController> logger)
	{
		_logger = logger;
	}

	public IActionResult RegisterHospital()
	{
		return View();
	}

	//public IActionResult Privacy()
	//{
	//	return View();
	//}

	//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	//public IActionResult Error()
	//{
	//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	//}
}
