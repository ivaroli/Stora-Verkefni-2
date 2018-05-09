using System;
using System.Collections.Generic;

namespace BookApp.Models
{
    public class cartViewModel
    {
        public List<OrderViewModel> Cart{get; set;}
        public int Total{get;set;}
    }
}