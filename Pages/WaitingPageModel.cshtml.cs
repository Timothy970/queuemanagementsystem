using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace assignmentapp.Pages
{
    public class WaitingPageModel : PageModel
    {
        private readonly ILogger<WaitingPageModel> _logger;
        private readonly AppDbContext _dbContext;

        public WaitingPageModel(ILogger<WaitingPageModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;


        }

        public Customer? Customer { get; set; }

        public void OnGet(int customerNumber)
        {
            // Retrieve customer information from the database
            Customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerNumber == customerNumber);
        }
    }
}
