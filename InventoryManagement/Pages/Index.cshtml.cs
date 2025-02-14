using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagement.Pages
{
    public class IndexModel : PageModel // indexModel is a child class of pageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            /*var firstName = Request.Form["fname"];
            var lastName = Request.Form["lname"];

            var name = firstName + lastName;
            */
        }

        public void OnPost()
        {

        }
    }
}
