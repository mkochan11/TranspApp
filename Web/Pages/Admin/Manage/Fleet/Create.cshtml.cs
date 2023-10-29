using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Web.Interfaces;

namespace Web.Pages.Admin.Manage.Fleet
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IFleetViewModelService _fleetViewModelService;
        private readonly IVehicleService _vehicleService;
        private readonly IRepository<Vehicle> _vehicleRepository;

        public CreateModel(IFleetViewModelService fleetViewModelService, IVehicleService vehicleService, IRepository<Vehicle> vehicleRepository)
        {
            _fleetViewModelService = fleetViewModelService;
            _vehicleService = vehicleService;
            _vehicleRepository = vehicleRepository;
            
        }

        public IEnumerable<VehicleType> vehicleTypes { get; set; } = new List<VehicleType>();

        public async Task OnGet()
        {
            vehicleTypes = await _fleetViewModelService.GetVehicleTypesList();
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Brand")]
            public required string Brand { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Model")]
            public required string Model { get; set; }

            [Required]
            [Range(1900, 2023, ErrorMessage = "The {0} must be between {1} and {2}")]
            [Display(Name = "Year of production")]
            public required int ProductionYear { get; set; }

            [Required(ErrorMessage = "Enter registration number")]
            [Display(Name = "Registration Number")]
            public required string RegistrationNumber { get; set; }

            [Required(ErrorMessage = "Choose vehicle type")]
            [Display(Name = "Vehicle Type")]
            public required string VehicleType { get; set; }

            [Required]
            [Range(0, 100000, ErrorMessage = "The {0} must be at least {1} and at max {2}")]
            [Display(Name = "Capacity")]
            public required int Capacity { get; set; }
        }

        public async Task<IActionResult> OnPost()
        {
            vehicleTypes = await _fleetViewModelService.GetVehicleTypesList();
            
            if (ModelState.IsValid)
            {
                var newVehicle = CreateVehicle();

                newVehicle.Brand = Input.Brand;
                newVehicle.Model = Input.Model;
                newVehicle.ProductionYear = Input.ProductionYear;
                newVehicle.RegistrationNumber = Input.RegistrationNumber;
                newVehicle.Capacity = Input.Capacity;
                newVehicle.PictureUri = null;

                var result = await _vehicleService.CreateAsync(newVehicle, Input.VehicleType);
                if (result.Succeeded)
                {
                    return RedirectToPage("./Index");
                }
                foreach(var error in result.Errors)
                {

                    if(error.Code == "registration_number_exists")
                    {
                        ModelState.AddModelError("Input.RegistrationNumber", error.Description);
                    }
                    if(error.Code == "vehicle_type_non_existent")
                    {
                        ModelState.AddModelError("Input.VehicleType", error.Description);
                    }
                }
                return Page();
            }
            else
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
        }

        private Vehicle CreateVehicle()
        {
            try
            {
                return Activator.CreateInstance<Vehicle>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Vehicle)}'.");
            }
        }

        
    }
}
