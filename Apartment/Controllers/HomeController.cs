using Apartment.Models;
using Apartment.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Apartment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApartmentRepository _repository;

        public HomeController(IApartmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]string? name, int take = 10, int skip = 0)
        {
            if (TempDataExist())
            {
                var viewModel = CreateViewModelFromTempData();
                viewModel.Apartments = await _repository.GetPaginatedAsync(viewModel.Name, viewModel.Take, viewModel.Skip);
                return View(viewModel);
            }
            else
            {
                var result = await _repository.GetPaginatedAsync(name, take, skip);
                var viewModel = new HomeViewModel { Apartments = result, Skip = skip, Take = take };
                return View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel viewModel)
        {
            TempData["name"] = viewModel.Name;
            TempData["take"] = viewModel.Take;
            TempData["skip"] = viewModel.Skip;
            return RedirectToAction("Index");
        }
         
        private HomeViewModel CreateViewModelFromTempData()
        {
            return new HomeViewModel
            {
                Skip = (int)TempData["skip"],
                Take = (int)TempData["take"],
                Name = TempData["name"]?.ToString()
            };
        }

        private bool TempDataExist()
        {
            return TempData.ContainsKey("name") && TempData.ContainsKey("take") && TempData.ContainsKey("skip");
        }
    }
}