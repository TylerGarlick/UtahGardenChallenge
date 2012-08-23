using System;
using System.Web.Mvc;
using UtahsOwnGardenChallenge.Mvc.Models.RegisterGardens;
using UtahsOwnGardenChallenge.Services;

namespace UtahsOwnGardenChallenge.Mvc.Controllers
{
	public class RegisterGardensController : Controller
	{
		public IGardenService GardenServices { get; set; }
		public ICountyService CountyService { get; set; }
		public IGardenTypeService GardenTypeService { get; set; }
		public IGardenSizeService GardenSizeService { get; set; }
		public IGardenReasonService GardenReasonService { get; set; }
		public IPlantTypeService PlantTypeService { get; set; }

		public RegisterGardensController(IGardenService gardenServices, ICountyService countyService, IGardenTypeService gardenTypeService,
			IGardenSizeService gardenSizeService, IGardenReasonService gardenReasonService, IPlantTypeService plantTypeService)
		{
			GardenServices = gardenServices;
			CountyService = countyService;
			GardenTypeService = gardenTypeService;
			GardenSizeService = gardenSizeService;
			GardenReasonService = gardenReasonService;
			PlantTypeService = plantTypeService;
		}

		public ActionResult Create()
		{
			var viewModel = SetupViewModel(new RegisterGardenModel() { IsWillingToBeContactedByNas = true });
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(RegisterGardenModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					model = SetupViewModel(model);
					return View(model);
				}

				var gardenResponse = GardenServices.RegisterGarden(new GardenRegistration()
											  {
												  Address = model.Address,
												  //CityId = model.CityId,
												  //CountyId = model.CountyId,
												  EmailAddress = model.EmailAddress,
												  FirstName = model.FirstName,
												  GardenName = model.GardenName,
												  GardenReasons = model.SelectedGardenReasons,
												  GardenSizeId = model.GardenSizeId,
												  GardenTypeId = model.GardenTypeId,
												  GroupName = model.GroupName,
												  PlantTypes = model.SelectedPlantTypes,
												  LastName = model.LastName,
												  Zipcode = model.ZipCode,
												  CanBeContactedByNas = model.IsWillingToBeContactedByNas,
												  City = model.City,
												  County = model.County
											  });

				if (gardenResponse.WasSuccessful)
					return RedirectToAction("ThankYou", new { id = gardenResponse.GardenId });

				model = SetupViewModel(model);
				return View(model);
			}
			catch (Exception ex)
			{
				model = SetupViewModel(model);
				ModelState.AddModelError("", ex.Message);
				return View(model);
			}
		}

		public ActionResult ThankYou(Guid id)
		{
			return View();
		}

		private RegisterGardenModel SetupViewModel(RegisterGardenModel model)
		{
			model.GardenSizes = GardenSizeService.GetGardenSizeSelectList();
			model.GardenTypes = GardenTypeService.GetGardenTypesSelectList();
			model.GardenReasons = GardenReasonService.GetAllGardenReasons();
			model.PlantTypes = PlantTypeService.GetAllPlantTypes();
			return model;
		}
	}
}
