using CoreLayer.Entities;
using CoreLayer.Interfaces;

namespace ApplicationLayer.Services
{
    public class UserService
    {
        private readonly IUser _userRepository;

        public UserService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public Users Login(string userName, string userPassword)
        {
            return _userRepository.ValidateUser(userName, userPassword);
        }
    }
}
