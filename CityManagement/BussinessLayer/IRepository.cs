using System;
using DataLayer;
using System.Collections.Generic;

namespace BussinessLayer
{
    public interface IRepository
    {
        void Create(City city);
        void Edit(City city);
        void Remove(int latitude, int longitude);
        City GetByCoordinates(int latitude, int longitude);
        IReadOnlyList<City> GetAll();
    }
}
