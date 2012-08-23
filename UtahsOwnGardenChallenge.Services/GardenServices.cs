using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UtahsOwnGardenChallenge.Data.Entities;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Services
{
	public interface IGardenService
	{
		GardenRegisterationResult RegisterGarden(GardenRegistration gardenRegistration);
		GardenResponse GetGardenById(Guid id);
	}

	public class GardenService : IGardenService
	{
		protected IGardenRepository GardenRepository { get; private set; }
		protected ICityRepository CityRepository { get; private set; }
		protected ICountyRepository CountyRepository { get; private set; }
		protected IGardenSizeRepository GardenSizeRepository { get; private set; }
		protected IGardenTypeRepository GardenTypeRepository { get; private set; }
		protected IGardenReasonRepository GardenReasonRepository { get; private set; }
		protected IPlantTypeRepository PlantTypeRepository { get; private set; }

		public GardenService(IGardenRepository gardenRepository, ICityRepository cityRepository,
			ICountyRepository countyRepository, IGardenSizeRepository gardenSizeRepository, IGardenTypeRepository gardenTypeRepository,
			IGardenReasonRepository gardenReasonRepository, IPlantTypeRepository plantTypeRepository)
		{
			GardenRepository = gardenRepository;
			CityRepository = cityRepository;
			CountyRepository = countyRepository;
			GardenSizeRepository = gardenSizeRepository;
			GardenTypeRepository = gardenTypeRepository;
			GardenReasonRepository = gardenReasonRepository;
			PlantTypeRepository = plantTypeRepository;
		}

		public GardenRegisterationResult RegisterGarden(GardenRegistration gardenRegistration)
		{
			var response = new GardenRegisterationResult();

			var validationResults = Validate(gardenRegistration);
			if (validationResults.Any())
			{
				response.ValidationResults = validationResults;
				return response;
			}

			//var city = CityRepository.ByKey(c => c.Id == gardenRegistration.CityId);
			//var county = CountyRepository.ByKey(c => c.Id == gardenRegistration.CountyId);
			var gardenSize = GardenSizeRepository.ByKey(gs => gs.Id == gardenRegistration.GardenSizeId);
			var gardenType = GardenTypeRepository.ByKey(gt => gt.Id == gardenRegistration.GardenTypeId);

			if (gardenSize != null && gardenType != null)
			{
				using (var transaction = new System.Transactions.TransactionScope())
				{
					var garden = new Garden()
					{
						Address = gardenRegistration.Address,
						CityName = gardenRegistration.City,
						Email = gardenRegistration.EmailAddress,
						FirstName = gardenRegistration.FirstName,
						GardenName = gardenRegistration.GardenName,
						GardenSize = gardenSize,
						GardenType = gardenType,
						GroupName = gardenRegistration.GroupName,
						CountyName = gardenRegistration.County,
						LastName = gardenRegistration.LastName,
						ZipCode = gardenRegistration.Zipcode,
						CanBeContactedByNas = gardenRegistration.CanBeContactedByNas
					};

					foreach (var gardenReason in gardenRegistration.GardenReasons.Select(gardenReasonId => GardenReasonRepository.ByKey(gr => gr.Id == gardenReasonId)))
						garden.GardenReasons.Add(gardenReason);

					foreach (var plantType in gardenRegistration.PlantTypes.Select(plantTypeId => PlantTypeRepository.ByKey(pt => pt.Id == plantTypeId)))
						garden.PlantTypes.Add(plantType);

					garden = GardenRepository.Add(garden);
					response.GardenId = garden.Id;
					response.WasSuccessful = true;
					transaction.Complete();
				}
			}
			return response;
		}

		public GardenResponse GetGardenById(Guid id)
		{
			var garden = GardenRepository.ByKey(g => g.Id == id);
			if (garden != null)
			{
				return new GardenResponse()
					   {
						   City = garden.City.Name,
						   EmailAddress = garden.Email,
						   FirstName = garden.FirstName,
						   GardenId = garden.Id,
						   GardenName = garden.GardenName,
						   GardenSize = garden.GardenSize.Name,
						   GardenType = garden.GardenType.Name,
						   GroupName = garden.GroupName,
						   LastName = garden.LastName,
						   Plants = garden.PlantTypes.Select(pt => pt.Name).ToList(),
						   Reasons = garden.GardenReasons.Select(gr => gr.Name).ToList(),
						   Zipcode = garden.ZipCode
					   };
			}

			return null;
		}

		private List<ValidationResult> Validate(GardenRegistration gardenRegistration)
		{
			var context = new ValidationContext(gardenRegistration, serviceProvider: null, items: null);
			var results = new List<ValidationResult>();
			Validator.TryValidateObject(gardenRegistration, context, results);
			return results;
		}
	}


	public class GardenRegisterationResult
	{
		public GardenRegisterationResult()
		{
			ValidationResults = new List<ValidationResult>();
			WasSuccessful = false;
		}

		public List<ValidationResult> ValidationResults { get; set; }
		public Guid GardenId { get; set; }
		public bool WasSuccessful { get; set; }
	}

	public class GardenRegistration : IValidatableObject
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string EmailAddress { get; set; }

		public string GardenName { get; set; }

		public string GroupName { get; set; }
		[Required]
		public string Address { get; set; }

		//public Guid CountyId { get; set; }
		//public Guid CityId { get; set; }

		[Required]
		public string City { get; set; }
		[Required]
		public string County { get; set; }
		public string Zipcode { get; set; }

		[Required]
		public Guid GardenSizeId { get; set; }

		[Required]
		public Guid GardenTypeId { get; set; }

		public IEnumerable<Guid> GardenReasons { get; set; }

		public IEnumerable<Guid> PlantTypes { get; set; }

		public bool CanBeContactedByNas { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			return new Collection<ValidationResult>();
		}
	}

	public class GardenResponse
	{
		public GardenResponse()
		{
			Reasons = new List<string>();
			Plants = new List<string>();
		}
		public Guid GardenId { get; set; }
		public string FirstName { get; set; }
		public string GardenName { get; set; }
		public string GroupName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string City { get; set; }
		public string Zipcode { get; set; }
		public string GardenSize { get; set; }
		public string GardenType { get; set; }
		public List<string> Reasons { get; set; }
		public List<string> Plants { get; set; }
	}
}
