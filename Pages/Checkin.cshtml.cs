using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace assignmentapp.Pages
{
    public class CheckInModel : PageModel
    {
        private readonly ILogger<CheckInModel> _logger;
        private readonly AppDbContext _dbContext;

        public CheckInModel(ILogger<CheckInModel> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [BindProperty]
        public string? ServiceType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Store customer information in the database
            var customer = new Customer
            {
                ServiceType = ServiceType,
                CheckInTime = DateTime.UtcNow,
                ServingTime = DateTime.UtcNow.AddMinutes(10), // Assuming 10 minutes serving time
                                                              // Set Teller based on the service type
                Teller = GetTeller(ServiceType)
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            // Redirect to the WaitingPage with the customer number
            return RedirectToPage("/WaitingPage", new { customerNumber = customer.CustomerNumber });
        }

        private string GetTeller(string? serviceType)
        {
            if (serviceType == null)
            {
                return "DefaultTeller";
            }
            switch (serviceType.ToLower())
            {
                case "deposit":
                    return "Teller01";
                case "withdraw":
                    return "Teller02";
                case "transfer":
                    return "Teller03";
                default:
                    return "DefaultTeller";
            }
        }

    }
}

