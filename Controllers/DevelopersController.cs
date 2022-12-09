using dotnetdevs.Models;
using dotnetdevs.Services;
using dotnetdevs.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetdevs.Controllers
{
	public class DevelopersController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly DeveloperService _developerService;
		private readonly UserService _userService;

		public DevelopersController(ILogger<HomeController> logger, DeveloperService developerService, UserService userService)
		{
			_logger = logger;
			_developerService = developerService;
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			DevelopersIndex model = new DevelopersIndex();
			model.Developers = await _developerService.GetAll();
			return View(model);
		}

		public async Task<IActionResult> Show(int id)
		{
			var developer = await _developerService.Get(id);
			if (developer == null)
			{
				return NotFound();
			}

			DevelopersShow model = new DevelopersShow();
			model.Developer = developer;
			return View(model);
		}
	}
}
