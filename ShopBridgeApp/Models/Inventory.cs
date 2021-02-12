using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridgeApp.Models
{
    public class Inventory
    {
       
        public int ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
       
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public decimal Price { get; set; }
        [DisplayName("Upload Image")]
        public string ImagePath { get; set; }

        public Inventory InvItem { get; set; }
        public List<Inventory> InventoryItemList { get; set; }
    }
}