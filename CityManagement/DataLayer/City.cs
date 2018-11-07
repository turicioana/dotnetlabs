using System;

namespace DataLayer
{
    public class City
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Description { set; get; }

        public int Latitude { set; get; }

        public int Longitude { set; get; }

        private City()
        {

        }

        public City(Guid id, string name, string description, int latitude, int longitude)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}
