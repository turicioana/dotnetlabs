using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BussinessLayer
{
    public class Repository : IRepository
    {
        private readonly CitiesContext _context;

        public Repository(CitiesContext context)
        {
            _context = context;
        }


        public void Create(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
        }

        public void Remove(int latitude, int longitude)
        {
            var removeCity = GetByCoordinates(latitude, longitude);
            _context.Cities.Remove(removeCity);
            _context.SaveChanges();
        }

        public void Edit(City city)
        {
            var existingCity = this._context.Cities.First(t => t.Id == city.Id);
            existingCity.Id = city.Id;
            existingCity.Name = city.Name;
            existingCity.Description = city.Description;
            existingCity.Latitude = city.Latitude;
            existingCity.Longitude = city.Longitude;
            _context.SaveChanges();

        }

        public City GetByCoordinates(int latitude, int longitude)
        {
            return this._context.Cities.FirstOrDefault(t => t.Latitude == latitude && t.Longitude == longitude);
        }

        public IReadOnlyList<City> GetAll()
        {
            return _context.Cities.ToList();
        }
    }
}
