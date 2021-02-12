using ShopBridgeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridgeApp.Interface
{
    public interface IInventory
    {

        List<Inventory> GetInventories();
        int SaveInventory(Inventory inventoryItem);
        int DeleteInventory(int ID);
    }
}
