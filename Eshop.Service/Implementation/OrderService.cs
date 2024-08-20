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

        public IEnumerable<OrderDetailsDto> GetAllOrderDetails()
        {
            var orders = _orderRepository.GetAll();

            var orderDetails = orders.Select(order => {
                var user = _userRepository.Get(order.EshopApplicationUserId.ToString());
                return new OrderDetailsDto
                {
                    Email = user?.Email,
                    FirstName = user?.FirstName,
                    LastName = user?.LastName,
                    TravelPackageName = order.TravelPackageInOrders?.FirstOrDefault()?.TravelPackage?.Name,
                    TotalPrice = order.TravelPackageInOrders?
                        .Sum(tpo => tpo.NumberOfTravelers * tpo.TravelPackage!.Price) ?? 0
                };
            }).ToList();

            return orderDetails;
        }
    }
}
