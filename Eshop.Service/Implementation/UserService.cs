using Eshop.DomainEntities;
using Eshop.Repository.Interface;
using Eshop.Service.Interface;
using System.Collections.Generic;

namespace Eshop.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Constructor to inject the IUserRepository dependency
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<EshopApplicationUser> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public EshopApplicationUser GetUserById(string id)
        {
            return _userRepository.Get(id);
        }

        public void AddUser(EshopApplicationUser user)
        {
            _userRepository.Insert(user);
        }

        public void UpdateUser(EshopApplicationUser user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(EshopApplicationUser user)
        {
            _userRepository.Delete(user);
        }
    }
}
