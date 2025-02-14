using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement.Pages.Purchases
{
    public class MakePurchaseModel : PageModel
    {
        [BindProperty]
        public int ShopperID { get; set; }

        [BindProperty]
        public int ProductID { get; set; }

        public List<SelectListItem> Shoppers { get; set; }

        public List<SelectListItem> Products { get; set; }

        public void OnGet()
        {
            // Populate the User SELECT control
            SqlDataReader ShopperReader = DBClass.GeneralReaderQuery("SELECT * FROM SHOPPER");

            Shoppers = new List<SelectListItem>();

            while (ShopperReader.Read())
            {
                Shoppers.Add(
                    new SelectListItem(
                        ShopperReader["ShopperName"].ToString(),
                        ShopperReader["ShopperID"].ToString()));
            }

            DBClass.GroceryDBConnection.Close();

            //Populate the Product SELECT control
            SqlDataReader ProductReader = DBClass.ProductReader();

            Products = new List<SelectListItem>();

            while (ProductReader.Read())
            {
                Products.Add(
                    new SelectListItem(
                        ProductReader["ProductName"].ToString(),
                        ProductReader["ProductID"].ToString()));
            }

            DBClass.GroceryDBConnection.Close();

        }

        public IActionResult OnPost()
        {
            string insertQuery = "INSERT INTO Purchase (ShopperID, ProductID, PurchaseQuantity) VALUES (";
            insertQuery += ShopperID + "," + ProductID + ",1)";

            DBClass.InsertQuery(insertQuery);

            DBClass.GroceryDBConnection.Close();

            return RedirectToPage("Index");
        }
    }
}
