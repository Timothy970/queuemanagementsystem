using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace assignmentapp.Pages
{

    public class ServicePointModel : PageModel
    {
        private readonly ILogger<ServicePointModel> _logger;
        private readonly AppDbContext _dbContext;

        public ServicePointModel(ILogger<ServicePointModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;

            CustomerQueue = new List<Customer>();
            SelectedTeller = "default";
            Tellers = new List<string>();
        }

        // Properties for the page
        public List<Customer> CustomerQueue { get; set; }
        public string SelectedTeller { get; set; }
        public List<string> Tellers { get; set; }

        // Handles HTTP GET request
        public IActionResult OnGet()
        {
            // Populate tellers for the dropdown
            Tellers = GetTellers();

            return Page();
        }

        // Handles HTTP POST request to load the customer queue based on the selected teller
        public PartialViewResult OnPostGetCustomerQueueForTeller(string teller)
        {
            // Retrieve the customer queue for the selected teller
            SelectedTeller = teller;
            CustomerQueue = GetCustomerQueueForTeller(teller);

            // Return the partial view with the updated customer queue
            return Partial("_CustomerQueuePartial", this);
        }

        // Example method to get all tellers
        private List<string> GetTellers()
        {
            // Retrieve tellers from the database or other data source
            // Modify this based on your actual tellers data
            var tellers = new List<string> { "Teller01", "Teller02", "Teller03" };

            return tellers;
        }

        // Example method to get the customer queue for a specific teller
        private List<Customer> GetCustomerQueueForTeller(string teller)
        {

            var customerQueue = _dbContext.Customers
                .Where(c => c.Teller == teller && c.Status == CustomerStatus.InQueue)
                .OrderBy(c => c.CheckInTime)
                .ToList();

            return customerQueue;
        }
    }
}
