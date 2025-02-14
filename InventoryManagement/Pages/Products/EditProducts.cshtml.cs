
using InventoryManagement.Pages.DataClasses;
using InventoryManagement.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace InventoryManagement.Pages.Products
{
    public class EditProductsModel : PageModel
    {
        [BindProperty]
        public Product ProductToUpdate { get; set; }

        public EditProductsModel()
        {
                ProductToUpdate = new Product();    
        }

        public void OnGet(int productid)
        {
            SqlDataReader singleProduct = DBClass.SingleProductReader(productid);

            while (singleProduct.Read())
            {
                ProductToUpdate.ProductID = productid;
                ProductToUpdate.ProductName = singleProduct["ProductName"].ToString();
                ProductToUpdate.ProductCost = Double.Parse(singleProduct["ProductCost"].ToString());
                ProductToUpdate.ProductDescription = singleProduct["ProductDescription"].ToString();
            }

            DBClass.GroceryDBConnection.Close();
        }

        public IActionResult OnPost()
        {
            DBClass.UpdateProduct(ProductToUpdate);

            DBClass.GroceryDBConnection.Close();

            return RedirectToPage("Index");
        }
    }
}
