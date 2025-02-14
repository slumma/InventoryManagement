
using InventoryManagement.Pages.DataClasses;
using InventoryManagement.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagement.Pages.Products
{
    public class AddProductsModel : PageModel
    {
        [BindProperty]
        public Product NewProduct { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBClass.InsertProduct(NewProduct);

            DBClass.GroceryDBConnection.Close();

            return RedirectToPage("Index");
        }
    }
}
