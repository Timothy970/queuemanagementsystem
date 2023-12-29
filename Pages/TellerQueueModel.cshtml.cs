using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignmentapp.Pages
{
    [Authorize]
    public class TellerQueueModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public TellerQueueModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            CustomerQueue = new List<Customer>();
            Teller = string.Empty;
        }

        [BindProperty]
        public string Teller { get; set; }

        public List<Customer> CustomerQueue { get; set; }

        public async Task<IActionResult> OnGetAsync(string teller)
        {
            // Set the selected teller
            Teller = teller;

            // Retrieve the customers in the queue for the selected teller
            CustomerQueue = await _dbContext.Customers
                .Where(c => c.Teller == Teller && c.ServingTime > DateTime.UtcNow)
                .OrderBy(c => c.CheckInTime)
                .ToListAsync();

            return Page();
        }

        public IActionResult OnPostUpdateCustomerStatus(string customerNumber, string action)
        {
            try
            {
                Console.WriteLine($"Recieved request with customerNumber: {customerNumber}, action: {action}");
                if (!int.TryParse(customerNumber, out int customerNumberInt) || string.IsNullOrEmpty(action))
                {
                    return BadRequest("Invalid customer number or action");
                }

                var customer = _dbContext.Customers.FirstOrDefault(c => c.CustomerNumber == customerNumberInt && c.Teller == Teller);
                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                // Update the customer status based on the action
                switch (action)
                {
                    case "Finish":
                        customer.Status = CustomerStatus.Finished;
                        break;
                    case "NoShow":
                        _dbContext.Customers.Remove(customer);
                        break;
                    case "Transfer":
                        var newTeller = GetNewTellerFromUser();
                        if (!string.IsNullOrEmpty(newTeller))
                        {
                            customer.Teller = newTeller;
                            customer.Status = CustomerStatus.Transferred;
                        }
                        else
                        {
                            return BadRequest("Invalid or empty teller for transfer");
                        }

                        break;
                    // Add more cases as needed

                    default:
                        return BadRequest("Invalid action");
                }

                _dbContext.SaveChanges();

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error performing action: {ex.Message}");
                return BadRequest($"Error performing action: {ex.Message}");
            }
        }
        private string? GetNewTellerFromUser()
        {
            Console.WriteLine("Enter the new teller:");
            return Console.ReadLine();
        }

    }
}

