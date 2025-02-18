using InventoryManagement.Pages.DataClasses;
using InventoryManagement.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace InventoryManagement.Pages.Practice
{
    public class StoredProcedureDemoModel : PageModel
    {

        public List<Product> InventoryList { get; set; }

        public StoredProcedureDemoModel()
        {
            // Needed because InventoryList is NOT a bound property!
            InventoryList = new List<Product>();
        }

        public void OnGet()
        {
            SqlDataReader ProductResults = DBClass.GeneralStoredProcedureReader("sp_selectProducts");    

            while (ProductResults.Read())
            {
                InventoryList.Add(new Product
                {
                    ProductName = ProductResults["ProductName"].ToString(),
                    ProductCost = Double.Parse(ProductResults["ProductCost"].ToString()),
                    ProductDescription = ProductResults["ProductDescription"].ToString()
                }) ;
            }

            DBClass.GroceryDBConnection.Close();

        }
    }
}
