using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ConfigureServiceProvidersModel : PageModel
{
    private readonly AppDbContext _dbContext;

    public ConfigureServiceProvidersModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        ExistingUsers = new List<ServiceProvider>();
    }

    // Existing users list for demonstration purposes
    public List<ServiceProvider> ExistingUsers { get; set; }

    [BindProperty]
    public string CurrentPassword { get; set; } = string.Empty;

    [BindProperty]
    public string NewPassword { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync()
    {
        // Fetch existing users from the database
        ExistingUsers = await _dbContext.ServiceProviders.ToListAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string serviceProviderName, string username, string password)
    {
        if (string.IsNullOrWhiteSpace(serviceProviderName) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            return BadRequest("Invalid input. Please provide all required information.");
        }

        // Check if the username is already taken
        if (_dbContext.ServiceProviders.Any(u => u.Username == username))
        {
            return BadRequest("Username is already taken. Choose a different username.");
        }

        var serviceProvider = new ServiceProvider
        {
            ServiceProviderName = serviceProviderName,
            Username = username,
            Password = password
        };

        _dbContext.ServiceProviders.Add(serviceProvider);
        await _dbContext.SaveChangesAsync();

        // Redirect to the same page after creating the account
        return RedirectToPage("/ConfigureServiceProviders");
    }

    public async Task<IActionResult> OnGetDeleteUserAsync(int id)
    {
        var userToDelete = await _dbContext.ServiceProviders.FindAsync(id);

        if (userToDelete != null)
        {
            _dbContext.ServiceProviders.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
        }

        // Redirect to the same page after deleting the user
        return RedirectToPage("/ConfigureServiceProviders");
    }

    public async Task<IActionResult> OnPostChangePasswordAsync(int id)
    {
        var serviceProvider = await _dbContext.ServiceProviders.FindAsync(id);

        if (serviceProvider == null)
        {
            // Handle the case where the user is not found
            return RedirectToPage("/ConfigureServiceProviders");
        }

        // Check if the current password matches the stored password
        if (serviceProvider.Password != CurrentPassword)
        {
            ModelState.AddModelError("CurrentPassword", "Incorrect current password.");
            return Page();
        }

        // Validate the new password (add more validation as needed)
        if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 5)
        {
            ModelState.AddModelError("NewPassword", "New password must be at least 5 characters.");
            return Page();
        }

        // Update the password with the new password
        serviceProvider.Password = NewPassword;
        await _dbContext.SaveChangesAsync();

        // Redirect to the same page after changing the password
        return RedirectToPage("/ConfigureServiceProviders");
    }
}
