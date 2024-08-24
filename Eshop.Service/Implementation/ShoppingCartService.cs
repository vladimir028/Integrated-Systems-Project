using Eshop.DomainEntities;
using Eshop.Repository.Interface;
using EShop.Repository.Interface;
using Eshop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _mailRepository;
        private readonly IRepository<TravelPackageInOrders> _productInOrderRepository;
        private readonly IRepository<TravelPackageInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IUserRepository userRepository, IRepository<Order> orderRepository, IRepository<TravelPackageInOrders> productInOrderRepository, IRepository<TravelPackageInShoppingCart> productInShoppingCartRepository, IRepository<EmailMessage> mailRepository, IEmailService emailService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _productInOrderRepository = productInOrderRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _mailRepository = mailRepository;
            _emailService = emailService;
        }


        public bool deleteProductFromSoppingCart(string userId, Guid productId)
        {
            if (!string.IsNullOrEmpty(userId) && productId != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.TravelPackagesInShoppingCarts.Where(z => z.TravelPackageId.Equals(productId)).FirstOrDefault();

                userShoppingCart.TravelPackagesInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }
            return false;
        }
        public ShoppingCartDto getShoppingCartInfo(string id)
        {

            var user = this._userRepository.Get(id);
            var shoppingCart = user.UserCart;

            ShoppingCartDto model = new ShoppingCartDto()
            {
                ProductsInShoppingCarts = shoppingCart.TravelPackagesInShoppingCarts ?? new List<TravelPackageInShoppingCart>(),
                TotalPrice = shoppingCart.TravelPackagesInShoppingCarts.Sum(z => z.NumberOfTravelers * z.TravelPackage.Price)

            };
            return model;
        }

        public bool AddToShoppingConfirmed(TravelPackageInShoppingCart model, string userId)
        {
            var user = this._userRepository.Get(userId);
            var shoppingCart = user.UserCart;
            TravelPackageInShoppingCart itemToAdd = new TravelPackageInShoppingCart
            {
                Id = Guid.NewGuid(),
                TravelPackage = model.TravelPackage,
                TravelPackageId = model.TravelPackageId,
                ShoppingCart = shoppingCart,
                ShoppingCartId = shoppingCart.Id,
                NumberOfTravelers = model.NumberOfTravelers
            };

            _productInShoppingCartRepository.Insert(itemToAdd);
            return true;

        }

        public bool order(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);
                var userCard = loggedInUser.UserCart;

                EmailMessage message = new EmailMessage();
                message.Subject = "Successfull order";
                message.MailTo = loggedInUser.Email;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    EshopApplicationUserId = Guid.Parse(userId),
                    EshopApplicationUser = loggedInUser
                };
                this._orderRepository.Insert(order);

                List<TravelPackageInOrders> productInOrders = new List<TravelPackageInOrders>();

                var result = userCard.TravelPackagesInShoppingCarts.Select(z => new TravelPackageInOrders
                {
                    Id = Guid.NewGuid(),
                    TravelPackageId = z.TravelPackage.Id,
                    TravelPackage = z.TravelPackage,
                    OrderId = order.Id,
                    UserOrder = order,
                    NumberOfTravelers = z.NumberOfTravelers
                }).ToList();

                StringBuilder sb = new StringBuilder();

                var totalPrice = 0.0;

                sb.AppendLine("Your order is completed. The order conatins: ");

                for (int i = 1; i <= result.Count(); i++)
                {
                    var currentItem = result[i - 1];
                    totalPrice += currentItem.NumberOfTravelers * currentItem.TravelPackage.Price;
                    sb.AppendLine(i.ToString() + ". " + currentItem.TravelPackage.Name + " with quantity of: " + currentItem.NumberOfTravelers + " and price of: $" + currentItem.TravelPackage.Price);
                }

                sb.AppendLine("Total price for your order: " + totalPrice.ToString());
                message.Content = sb.ToString();


                productInOrders.AddRange(result);

                foreach (var item in productInOrders)
                {
                    this._productInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.TravelPackagesInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);
                this._mailRepository.Insert(message);
                this._emailService.SendEmailAsync(message);
                return true;
            }

            return false;
        }
    }
}
