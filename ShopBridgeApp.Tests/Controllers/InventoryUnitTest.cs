using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridgeApp.Controllers;
using ShopBridgeApp.Interface;
using ShopBridgeApp.Models;

namespace ShopBridgeApp.Tests.Controllers
{
    [TestClass]
    public class InventoryUnitTest
    {
        private static IInventory _inventoryRepositary;
       
        public InventoryUnitTest(IInventory _repositary)
        {
            _inventoryRepositary = _repositary;
           
        }
        [TestMethod]
        public void GetInventoryItems()
        {
         
            var items=_inventoryRepositary.GetInventories();
            Assert.IsNotNull(items, "Result is null");
           
        }
        [TestMethod]
        public void DeleteItems()
        {
             int i= _inventoryRepositary.DeleteInventory(1);

             Assert.IsTrue(i == 1);
        }
        [TestMethod]
        public void PostItem()
        {
            int i = _inventoryRepositary.SaveInventory(new Inventory { ID = 1, Name = "Item1", Description = "Desc1", Price = 10, ImagePath = "~/Content/Images/test1.jpg" });
            Assert.IsTrue(i == 1);
        }

    }
}
