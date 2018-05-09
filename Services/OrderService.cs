using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;
using System.Security.Cryptography;
using System.Text;
using BookApp.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BookApp.Services
{
    public class OrderService
    {
        private OrderRepository orderRepository;
        
        public OrderService()
        {
            orderRepository = new OrderRepository();
        }

        public void AddToCart(OrderInputModel input)
        {
            orderRepository.AddToCart(input);
        }

        public List<OrderViewModel> GetCart(string uId)
        {
            return orderRepository.GetCart(uId);
        }
    }
}