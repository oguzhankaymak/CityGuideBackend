using System.Collections.Generic;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace CityGuide.API.Models
{
    public class City : IEntity
    {
        public City()
        {
            Photos = new List<Photo>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public List<Photo> Photos { get; set; }
        public User user { get; set; }
    }
}