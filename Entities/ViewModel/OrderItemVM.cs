using System.ComponentModel.DataAnnotations;
using Entities.Models;
using X.PagedList;

namespace Entities.ViewModel
{
    public class OrderItemVM
    {
        public int ItemId { get; set; }

        public int ModifierId { get; set; }

        public string UId { get; set; }

        public string ItemName { get; set; }

        public int Readyitemquantity { get; set; }

        public decimal Rate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }

        public string Comment { get; set; }

        public string ItemInstructions { get; set; }

        public string Status { get; set; }
        public int OrderId { get; set; }
        public List<OrderModifierVM> Modifiers { get; set; }
         public List<OrderModifierVM> OrderModifiers { get; set; } = new List<OrderModifierVM>();

        public List<MenuModifierGroupVM> MenuItemModifier { get; set; }



    }
}