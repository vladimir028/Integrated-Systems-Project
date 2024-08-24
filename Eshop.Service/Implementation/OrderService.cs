using Eshop.DomainEntities;
using EShop.Repository.Interface;
using Eshop.DomainEntities.DTO;
using Eshop.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using Eshop.Repository.Interface;

namespace Eshop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IRepository<Order> orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Order> GetAllOrderDetails()
        {
            return _orderRepository.GetAll();
        }

        public Order GetDetailsForOrder(BaseEntity model)
        {
            return _orderRepository.Get(model.Id);
        }
    }
}
