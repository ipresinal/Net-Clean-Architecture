using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using CustomerApp.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _customerRepo;

        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepo = orderRepository;
            _customerRepo = customerRepository;
        }

        public Order New()
        {
            return new Order();
        }

        public Order CreateOrder(Order order)
        {
            if (order.Customer == null || order.Customer.Id <= 0)
                throw new InvalidDataException("To create Order you need a Customer");

            if (_customerRepo.ReadById(order.Customer.Id) == null)
                throw new InvalidDataException("Customer Not found");

            if(order.OrderDate == null)
                throw new InvalidDataException("Order needs a Order Date");

            return _orderRepo.Create(order);
        }        

        public Order FindOrderById(int id)
        {
            return _orderRepo.ReadById(id);
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepo.ReadAll().ToList();
        }
       
        public Order UpdateOrder(Order orderUpdate)
        {
            return _orderRepo.Update(orderUpdate);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepo.Delete(id);
        }
    }
}
