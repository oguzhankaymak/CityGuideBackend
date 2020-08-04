using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}