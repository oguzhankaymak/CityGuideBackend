using System.Collections.Generic;
using CityGuide.API.Models;

namespace WebAPI.Models
{
    public class CityDetailDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Photo> Photos { get; set; }
    }
}