using BookApp.Models;
using BookApp.Services;
using BookApp.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BookApp.Repositories
{
     
    public class OrderRepository
    {
        private Data.DataContext db;
        
        public OrderRepository()
        {
            db = new DataContext();
        }

        public void AddToCart(OrderInputModel order)
        {
            var newOrder = new CartOrder(){
                amount = order.amount,
                UserId = order.UserId,
                ExpirationTime = order.ExpirationTime,
                BookId = order.BookId
            };

            db.Carts.Add(newOrder);
            db.SaveChanges();
        }

        public void AddToWishlist(OrderInputModel order)
        {
            var newOrder = new Wish(){
                amount = order.amount,
                UserId = order.UserId,
                ExpirationTime = order.ExpirationTime,
                BookId = order.BookId
            };

            db.WishLists.Add(newOrder);
            db.SaveChanges();
        }

        public List<OrderViewModel> GetCart(string uId)
        {
            var cart = (from c in db.Carts
                        where c.UserId == uId && c.ExpirationTime > DateTime.Now
                        join b in db.Books on c.BookId equals b.Id
                        select new OrderViewModel(){
                            Id = c.Id,
                            amount = c.amount,
                            UserId = c.UserId,
                            ExpirationTime = c.ExpirationTime,
                            OrderBook = new BookOrderViewModel(){
                                Title = b.Title,
                                Price = b.Price,
                                Image = b.Image
                           }
                        }).ToList();
            return cart;
        }

        public List<OrderViewModel> GetWishlist(string uId)
        {
            var cart = (from c in db.WishLists
                        where c.UserId == uId && c.ExpirationTime > DateTime.Now
                        join b in db.Books on c.BookId equals b.Id
                        select new OrderViewModel(){
                            Id = c.Id,
                            amount = c.amount,
                            UserId = c.UserId,
                            ExpirationTime = c.ExpirationTime,
                            OrderBook = new BookOrderViewModel(){
                                Title = b.Title,
                                Price = b.Price,
                                Image = b.Image
                           }
                        }).ToList();
            return cart;
        }

        public void RemoveFromCart(int id)
        {
            var orderToRemove = (from c in db.Carts
                                 where c.Id == id
                                 select c).FirstOrDefault();
            Console.WriteLine("\n**REMOVING: " + orderToRemove.Id);
            db.Carts.Remove(orderToRemove);
            db.SaveChanges();
            Console.WriteLine("\n**REMOVING COMPLETE");
        }

        public void RemoveFromWishlist(int id)
        {
            var orderToRemove = (from c in db.WishLists
                                 where c.Id == id
                                 select c).FirstOrDefault();
            Console.WriteLine("\n**REMOVING: " + orderToRemove.Id);
            db.WishLists.Remove(orderToRemove);
            db.SaveChanges();
            Console.WriteLine("\n**REMOVING COMPLETE");
        }

        public bool isInCart(int bookId, string uId)
        {
            var isInDatabase = (from c in db.Carts
                                where c.BookId == bookId && c.UserId == uId
                                select c).Any();
            return isInDatabase;
        }

        public bool isInWishlist(int bookId, string uId)
        {
            var isInDatabase = (from c in db.WishLists
                                where c.BookId == bookId && c.UserId == uId
                                select c).Any();
            return isInDatabase;
        }
    }
}