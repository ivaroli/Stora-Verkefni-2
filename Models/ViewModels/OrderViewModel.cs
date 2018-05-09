using System;
namespace BookApp.Models
{
    public class OrderViewModel
    {
        public int Id{get; set;}
        public int amount{get; set;}
        public string UserId{get;set;}
        public DateTime ExpirationTime{get; set;}
        public BookOrderViewModel OrderBook{get; set;}
    }
}