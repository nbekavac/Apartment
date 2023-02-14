using Apartment.Models;
using Apartment.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apartment.Controllers
{
    public class ApartmentDetailsController : Controller
    {
        private readonly IApartmentRepository _repository;

        public ApartmentDetailsController(IApartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = new ApartmentDetailsViewModel { Apartment = result };
            return View(viewModel);
        }
    }
}
