using Eshop.DomainEntities;
using System.Collections.Generic;

namespace Eshop.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<EshopApplicationUser> GetAllUsers();
        EshopApplicationUser GetUserById(string id);
        void AddUser(EshopApplicationUser user);
        void UpdateUser(EshopApplicationUser user);
        void DeleteUser(EshopApplicationUser user);
    }
}
