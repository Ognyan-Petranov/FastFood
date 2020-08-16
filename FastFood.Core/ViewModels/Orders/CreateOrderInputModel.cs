using FastFood.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required]
        public string Customer { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public OrderType OrderType { get; set; }

    }
}
