using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagement.Pages.Practice
{
    public class DisplayDataModel : PageModel
    {
        public int UserID { get; set; }

        public void OnGet(int userID)
        {
            UserID = userID;

        }
    }
}
