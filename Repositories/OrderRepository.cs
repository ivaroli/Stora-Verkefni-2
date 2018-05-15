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

        //bætir order í cart
        public void AddToCart(OrderInputModel order)
        {
            var newOrder = new CartOrder()
            {
                amount = order.amount,
                UserId = order.UserId,
                ExpirationTime = order.ExpirationTime,
                BookId = order.BookId
            };

            db.Carts.Add(newOrder);
            db.SaveChanges();
        }

        //bætir order í wishlist
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

        //Nær í all sem er í cart útfrá auðkenni notenda
        public List<OrderViewModel> GetCart(string uId)
        {
            var cart = (from c in db.Carts
                        where c.UserId == uId && c.ExpirationTime > DateTime.Now
                        join b in db.Books on c.BookId equals b.Id
                        select new OrderViewModel()
                        {
                            Id = c.Id,
                            amount = c.amount,
                            UserId = c.UserId,
                            ExpirationTime = c.ExpirationTime,
                            OrderBook = new BookOrderViewModel()
                            {
                                Title = b.Title,
                                Price = b.Price,
                                Image = b.Image
                           }
                        }).ToList();
            return cart;
        }

        //Nær í all sem er í wishlist útfrá auðkenni notenda
        public List<OrderViewModel> GetWishlist(string uId)
        {
            var cart = (from c in db.WishLists
                        where c.UserId == uId && c.ExpirationTime > DateTime.Now
                        join b in db.Books on c.BookId equals b.Id
                        select new OrderViewModel()
                        {
                            Id = c.Id,
                            amount = c.amount,
                            UserId = c.UserId,
                            ExpirationTime = c.ExpirationTime,
                            OrderBook = new BookOrderViewModel()
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Price = b.Price,
                                Image = b.Image,
                                Author = b.Author.Name
                           }
                        }).ToList();
            return cart;
        }

        //Nær í allar pantanir útfrá auðkenni notenda
        public List<OrderViewModel> GetOrders(string uId)
        {
            var cart = (from c in db.Orders
                        where c.UserId == uId && c.ExpirationTime > DateTime.Now
                        join b in db.Books on c.BookId equals b.Id
                        select new OrderViewModel()
                        {
                            Id = c.Id,
                            amount = c.amount,
                            UserId = c.UserId,
                            ExpirationTime = c.ExpirationTime,
                            OrderBook = new BookOrderViewModel()
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Price = b.Price,
                                Image = b.Image,
                                Author = b.Author.Name
                           }
                        }).ToList();
            return cart;
        }

        ////eyðir bók sem er í cart
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

        //Eyðir bók sem er í wishlist
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

        //skilar true ef bók er í cart hjá notenda annars skilar false
         public bool isInCart(int bookId, string uId)
        {
            var isInDatabase = (from c in db.Carts
                                where c.BookId == bookId && c.UserId == uId
                                select c).Any();
            return isInDatabase;
        }

        //skilar true ef bók er í wishlist hjá notenda annars skilar false
        public bool isInWishlist(int bookId, string uId)
        {
            var isInDatabase = (from c in db.WishLists
                                where c.BookId == bookId && c.UserId == uId
                                select c).Any();
            return isInDatabase;
        }

        //Eyðir öllu sem er í cart útfrá auðkenni notenda
        public void ClearCart(string uId)
        {
            var toRemove = (from c in db.Carts
                            where c.UserId == uId
                            select c).ToList();
            db.Carts.RemoveRange(toRemove);
            db.SaveChanges();
        }

        //Færir allt sem er í cart yfir í orders
        public void CartToOrders(string uId)
        {
            var toAdd = (from c in db.Carts
                            where c.UserId == uId
                            select new Order
                            {
                                amount = c.amount,
                                UserId = c.UserId,
                                ExpirationTime = DateTime.Now.AddDays(20),
                                BookId = c.BookId

                            }).ToList();
            db.Orders.AddRange(toAdd);
            db.SaveChanges();
            ClearCart(uId);
        }
    }
}