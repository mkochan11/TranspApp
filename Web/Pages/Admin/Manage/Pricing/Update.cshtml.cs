using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Web.Interfaces.Admin.Manage.Pricing;

namespace Web.Pages.Admin.Manage.Pricing
{
    public class UpdateModel : PageModel
    {
        private readonly IRepository<VehicleType> _vehicleTypesRepository;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IUpdateViewModelService _updateViewModelService;

        static int VehicleTypeId;
        public VehicleType UpdatedVehicleType { get; set; }

        public UpdateModel(IRepository<VehicleType> vehicleTypeRepository, IVehicleTypeService vehicleTypeService, IUpdateViewModelService updateViewModelService)
        {
            _vehicleTypesRepository = vehicleTypeRepository;
            _vehicleTypeService = vehicleTypeService;
            _updateViewModelService = updateViewModelService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [Display(Name = "Type")]
            public required string Type { get; set; }

            [Required]
            [Range(0, 1000000, ErrorMessage = "The {0} must be a non negative number")]
            [Display(Name = "Price")]
            public required float Price { get; set; }
        }
        public async Task OnGet()
        {
            if (TempData.ContainsKey("VehicleTypeId") && TempData["VehicleTypeId"] is int Id)
            {
                VehicleTypeId = Id;
            }
            else
            {
                throw new Exception("Vehicle type not found");
            }

            UpdatedVehicleType = CreateVehicleType();
            UpdatedVehicleType = await _updateViewModelService.GetVehicleTypeByIdAsync(VehicleTypeId);
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                UpdatedVehicleType = CreateVehicleType();
                UpdatedVehicleType = await _updateViewModelService.GetVehicleTypeByIdAsync(VehicleTypeId);
                UpdatedVehicleType.PricePer100km = Input.Price;
                UpdatedVehicleType.Type = Input.Type;

                var result = await _vehicleTypeService.UpdateAsync(UpdatedVehicleType);
                if (result.Succeeded)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        if (error.Code == "vehicle_type_already_exists")
                        {
                            ModelState.AddModelError("Input.Type", error.Description);
                        }
                    }
                    return Page();
                }
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
        private VehicleType CreateVehicleType()
        {
            try
            {
                return Activator.CreateInstance<VehicleType>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(VehicleType)}'.");
            }
        }
    }
}
