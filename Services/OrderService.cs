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

        public void AddToWishlist(OrderInputModel input)
        {
            orderRepository.AddToWishlist(input);
        }

        public CartViewModel GetCart(string uId)
        {
            var orders = orderRepository.GetCart(uId);
            int total = 0;

            foreach(var order in orders){
                total += order.amount * order.OrderBook.Price;
            }

            var model = new CartViewModel(){
                Cart = orders,
                Total = total
            };

            return model;
        }

        public CartViewModel GetWishlist(string uId)
        {
            var orders = orderRepository.GetWishlist(uId);
            int total = 0;

            foreach(var order in orders){
                total += order.amount * order.OrderBook.Price;
            }

            var model = new CartViewModel(){
                Cart = orders,
                Total = total
            };

            return model;
        }

        public void RemoveFromCart(int id)
        {
            orderRepository.RemoveFromCart(id);
        }

        public void RemoveFromWishlist(int id)
        {
            orderRepository.RemoveFromWishlist(id);
        }

        public bool isInCart(int bookId, string uId)
        {
            return orderRepository.isInCart(bookId, uId);
        }

        public bool isInWishlist(int bookId, string uId)
        {
            return orderRepository.isInWishlist(bookId, uId);
        }
    }
}