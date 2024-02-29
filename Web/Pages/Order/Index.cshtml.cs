using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;

namespace Web.Pages.Order
{
    [Authorize(Policy="User")]
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;
        public void OnGet()
        {
        }

        public IndexModel(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [BindProperty]
        public required InputAddressModel InputStartingAddress { get; set; }
        [BindProperty]
        public required InputAddressModel InputDestinationAddress { get; set; }
        [BindProperty]
        public required InputOrderModel InputOrder { get; set; }

        public class InputOrderModel
        {
            [Required(ErrorMessage = "Enter date of execution")]
            [Display(Name = "Date of Order execution")]
            public required DateTime Date { get; set; }

            [Required]
            [Range(100, 10000, ErrorMessage = "The {0} must be at least {1} and at max {2} kgs")]
            [Display(Name = "Order weight")]
            public required float Weight { get; set; }
        }
        public class InputAddressModel
        {

            [Required(ErrorMessage = "Enter country")]
            [Display(Name = "Country")]
            public required string Country { get; set; }

            [Required(ErrorMessage = "Enter city")]
            [Display(Name = "City")]
            public required string City { get; set; }

            [Required(ErrorMessage = "Enter postal code")]
            [Display(Name = "Postal code")]
            public required string PostalCode { get; set; }

            [Required(ErrorMessage = "Enter street")]
            [Display(Name = "Street")]
            public required string Street { get; set; }

            [Required(ErrorMessage = "Enter house number")]
            [Display(Name = "House number")]
            public required string HouseNumber { get; set; }

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
               .Where(x => x.Value.Errors.Count > 0)
               .Select(x => new { x.Key, x.Value.Errors })
               .ToList();

                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Key, error.Errors[0].ErrorMessage);
                }
                return Page();
            }
            else
            {
                var StartingAddress = _orderService.CreateAddress(InputStartingAddress.Country, InputStartingAddress.City, InputStartingAddress.PostalCode, InputStartingAddress.Street, InputStartingAddress.HouseNumber).Result;
                var DestinationAddress = _orderService.CreateAddress(InputDestinationAddress.Country, InputDestinationAddress.City, InputDestinationAddress.PostalCode, InputDestinationAddress.Street, InputDestinationAddress.HouseNumber).Result;
                
                Guard.Against.Null(Request.HttpContext.User.Identity, nameof(Request.HttpContext.User.Identity));
                string? userName = null;

                if (Request.HttpContext.User.Identity.IsAuthenticated)
                {
                    Guard.Against.Null(Request.HttpContext.User.Identity.Name, nameof(Request.HttpContext.User.Identity.Name));
                    userName = Request.HttpContext.User.Identity.Name;
                }

                var newOrder = _orderService.CreateOrder(userName, StartingAddress.Id, DestinationAddress.Id, InputOrder.Weight, InputOrder.Date);

                var res = _orderService.CheckIfOrderExists(newOrder.Result.Id).Result;

                if (res) return RedirectToPage("./OrderConfirmation"); else return RedirectToPage("./OrderError");

            }
        }
    }
}
