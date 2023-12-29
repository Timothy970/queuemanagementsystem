using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;


public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginModel(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public void OnGet()
    {
        // Display the login form
    }

    public async Task<IActionResult> OnPostAsync(string username, string password)
    {
        // Validate the username and password
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

        // Check if authentication was successful
        if (result.Succeeded)
        {
            // Redirect to the TellerQueue page if successful
            return RedirectToPage("/TellerQueue");
        }
        else
        {
            // Authentication failed, you might want to add a ModelState error or handle it appropriately
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
