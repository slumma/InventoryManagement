using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Pages.Practice
{
    public class DisplayNameModel : PageModel
    {
        // Data Annotation Tag 
        [BindProperty]
        [Required]
        public String FirstName{ get; set; }

        [BindProperty]
        [Required]
        public String SecondName{ get; set; }
        
        public void OnGet()
        {


        }

        public IActionResult OnPost()
        {
            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear(); // modelstate is the objct that contains all of the information on the state of th data model
            SecondName = "Smith";

            return Page();  


        }
    }
}
