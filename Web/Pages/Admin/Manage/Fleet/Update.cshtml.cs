using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Interfaces;
using System.ComponentModel.DataAnnotations;
using Web.Interfaces.User;
using ApplicationCore.Services;
using Web.Interfaces.Admin.Manage.Fleet;
using ApplicationCore.Entities.VehicleAggregate;

namespace Web.Pages.Admin.Manage.Fleet
{
    [Authorize(Policy = "Admin")]
    public class UpdateModel : PageModel
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IRepository<VehicleType> _vehicleTypeRepository;
        private readonly IUpdateViewModelService _updateViewModelService;
        private readonly IVehicleService _vehicleService;

        //public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public IEnumerable<VehicleType> VehicleTypes { get; set; } = new List<VehicleType>();
        public Vehicle UpdatedVehicle { get; set; }
        public Vehicle NewVehicle;
        static int VehicleId { get; set; }

        public UpdateModel( IRepository<Vehicle> vehicleRepository, IRepository<VehicleType> vehicleTypeRepository, IUpdateViewModelService updateViewModelService, IVehicleService vehicleService)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
            _updateViewModelService = updateViewModelService;
            _vehicleService = vehicleService;

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
        public async Task OnGet()
        {

            if(TempData.ContainsKey("VehicleId") && TempData["VehicleId"] is int Id)
            {
                VehicleId = Id;
            }
            else
            {
                RedirectToPagePermanent("/Error");
            }

            VehicleTypes = await _vehicleTypeRepository.ListAsync();
            UpdatedVehicle = CreateVehicle();
            UpdatedVehicle = await _updateViewModelService.GetVehicleByIdAsync(VehicleId);

        }

        public async Task<IActionResult> OnPost()
        {
            VehicleTypes = await _vehicleTypeRepository.ListAsync();

            if (ModelState.IsValid)
            {
                UpdatedVehicle = CreateVehicle();
                UpdatedVehicle = await _updateViewModelService.GetVehicleByIdAsync(VehicleId);
                UpdatedVehicle.Brand = Input.Brand;
                UpdatedVehicle.Model = Input.Model;
                UpdatedVehicle.ProductionYear = Input.ProductionYear;
                UpdatedVehicle.RegistrationNumber = Input.RegistrationNumber;
                UpdatedVehicle.Capacity = Input.Capacity;
                UpdatedVehicle.PictureUri = null;

                var result = await _vehicleService.UpdateAsync(UpdatedVehicle, Input.VehicleType);
                if (result.Succeeded)
                {
                    return RedirectToPage("./Index");
                }
                foreach (var error in result.Errors)
                {

                    if (error.Code == "registration_number_exists")
                    {
                        ModelState.AddModelError("Input.RegistrationNumber", error.Description);
                    }
                    if (error.Code == "vehicle_type_non_existent")
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
