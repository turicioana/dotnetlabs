using System;
using Microsoft.AspNetCore.Mvc;
using BussinessLayer;
using System.Linq;
using CityManagement.ViewModels;
using DataLayer;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace CityManagement.Controllers
{
    public class CityController : Controller
    {
        private readonly IRepository _repository;

        private int previousLatitude;

        private int previousLongitude;
        

        public CityController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var cities = _repository.GetAll();
            var citiesMapped = cities
                .Select(city => 
                    new CityViewModel
                    {
                        Name = city.Name,
                        Description = city.Description,
                        Latitude = city.Latitude,
                        Longitude = city.Longitude
                    })
                    .ToList();
            return View(citiesMapped);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create([Bind("Name,Description,Latitude,Longitude")]
            CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newCity = new City(new Guid(), model.Name, model.Description, model.Latitude, model.Longitude);
                _repository.Create(newCity);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int latitude, int longitude)
        {
            if (latitude == null || longitude == null)
            {
                return NotFound();
            }

            var city = _repository.GetByCoordinates(latitude,longitude);
            var specificCity = new CityViewModel
            {
                Name = city.Name,
                Description = city.Description,
                Latitude = city.Latitude,
                Longitude = city.Longitude
            };

            if (specificCity == null)
            {
                return NotFound();
            }

            return View(specificCity);
        }

        public IActionResult Edit(int latitude, int longitude)
        {
            if (latitude == null || longitude == null)
            {
                return NotFound();
            }

            var city = _repository.GetByCoordinates(latitude, longitude);
            var specificCity = new CityViewModel
            {
                Name = city.Name,
                Description = city.Description,
                Latitude = city.Latitude,
                Longitude = city.Longitude
            };

            if (specificCity == null)
            {
                return NotFound();
            }

            previousLatitude = latitude;
            previousLongitude = longitude;
            return View(specificCity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int latitude, int longitude,[Bind("Name, Description,Latitude,Longitude")]
            CityViewModel model)
        {

            if (ModelState.IsValid)
            {
                var city = _repository.GetByCoordinates(previousLatitude, previousLongitude);
                var updatedCity = new City(city.Id, model.Name, model.Description, model.Latitude, model.Longitude);
                _repository.Edit(updatedCity);
                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }

        public IActionResult Delete(int latitude, int longitude)
        {
            if (latitude == null || longitude == null)
            {
                return NotFound();
            }

            var city = _repository.GetByCoordinates(latitude, longitude);
            var specificCity = new CityViewModel
            {
                Name = city.Name,
                Description = city.Description,
                Latitude = city.Latitude,
                Longitude = city.Longitude
            };

            if (specificCity == null)
            {
                return NotFound();
            }

            return View(specificCity);
        }

        public IActionResult DeleteConfirmed(int latitude, int longitude)
        {
            _repository.Remove(latitude, longitude);
            return RedirectToAction(nameof(Index));
        }

    }
}