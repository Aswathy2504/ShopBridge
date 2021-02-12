using ShopBridgeApp.Interface;
using ShopBridgeApp.Models;
using ShopBridgeApp.Repositary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridgeApp.Controllers
{
    public class InventoryController : Controller
    {
        private static IInventory _inventoryRepositary;
       public InventoryController(IInventory _repositary)
        {
            _inventoryRepositary = _repositary;
        }
        // GET: Inventory
        [HttpGet]
        public ActionResult Add()
        {
           
            ModelState.Clear();
            var itemList = _inventoryRepositary.GetInventories();
            var itemData = new Inventory()
            {
                InventoryItemList = itemList.ToList()
            };
            return View(itemData);
        }
        [HttpPost]
     
        public ActionResult Add(Inventory inventory,HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ImageFile == null)
                    {
                       inventory.ImagePath = "~/Content/Images/noimage/noimage.jpg";
                    }
                    else
                    {

                        string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        string extension = Path.GetExtension(ImageFile.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        inventory.ImagePath = "~/Content/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                        ImageFile.SaveAs(fileName);
                    }

                    int returnVal = _inventoryRepositary.SaveInventory(inventory);


                    if (returnVal == 0)
                    {
                        TempData["Message"] = "Details already exists";
                    }
                    else if (returnVal == 1)
                    {
                        TempData["Message"] = "Saved Successfully";
                    }
                   
                }
                return RedirectToAction("Add");

            }
            catch (Exception ex)
            {

                TempData["Message"] = "Error occured";
                return View();
            }
        }

        [Route("Delete/{id})")]
        public ActionResult Delete(int id)
        {
            try
            {

                int returnVal = _inventoryRepositary.DeleteInventory(id);
                if (returnVal == 1)
                {
                    TempData["Message"] = "Details deleted successfully";
                }
                return RedirectToAction("Add");

            }
            catch
            {
                TempData["Message"] = "Error occured";
                return View();
            }
        }

        [Route("Edit/{id})")]
        public ActionResult Edit(int id)
        {
            return View("Edit", _inventoryRepositary.GetInventories().Find(Inventory => Inventory.ID == id));
        }

    }
}