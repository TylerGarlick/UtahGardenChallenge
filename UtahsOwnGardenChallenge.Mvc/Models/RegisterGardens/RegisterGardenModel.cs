using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Mvc.Models.RegisterGardens
{
	public class RegisterGardenModel
	{
		public RegisterGardenModel()
		{
			IsWillingToEmailed = true;
			IsWillingToContactedByUtahsOwn = true;
		}
		[Required(ErrorMessage = "First Name is required."), Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required."), Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email Address is required."), Display(Name = "Email Address")]
		public string EmailAddress { get; set; }

		[Display(Name = "Garden Name")]
		public string GardenName { get; set; }

		[Display(Name = "Group Name")]
		public string GroupName { get; set; }

		[Required(ErrorMessage = "Address is required."), Display(Name = "Address")]
		public string Address { get; set; }

		//[Required(ErrorMessage = "County is required."), Display(Name = "County")]
		//public Guid CountyId { get; set; }
		//public IEnumerable<SelectListItem> Counties { get; set; }

		[Required(ErrorMessage = "County is required."), Display(Name = "County")]
		public string County { get; set; }


		//[Required(ErrorMessage = "City is required."), Display(Name = "City")]
		//public Guid CityId { get; set; }
		
		[Required(ErrorMessage = "City is required."), Display(Name = "City")]
		public string City { get; set; }

		[Required(ErrorMessage = "Zip Code is required."), Display(Name = "Zip Code")]
		public string ZipCode { get; set; }

		[Required(ErrorMessage = "Garden Size is required."), Display(Name = "Garden Size")]
		public Guid GardenSizeId { get; set; }
		public IEnumerable<SelectListItem> GardenSizes { get; set; }

		[Display(Name="Garden Type"), Required( ErrorMessage = "Garden Type is required.")]
		public Guid GardenTypeId { get; set; }
		public IEnumerable<SelectListItem> GardenTypes { get; set; }

		[Display(Name = "Garden Types")]
		public IEnumerable<GardenReason> GardenReasons { get; set; }
		public List<Guid> SelectedGardenReasons { get; set; }

		[Display(Name = "Plant Types")]
		public IEnumerable<PlantType> PlantTypes { get; set; }
		public List<Guid> SelectedPlantTypes { get; set; }

		[Display(Name = "To be eligible to receive prizes, you must opt in to receive emails from the Utah Garden Challenge.")]
		public bool IsWillingToEmailed { get; set; }

		[Display(Name = "Check this box to recieve additional information from Utah's Own (i.e. Local Food, Agritainment and AgriTourism)")]
		public bool IsWillingToContactedByUtahsOwn { get; set; }

		public bool IsWillingToBeContactedByNas { get; set; }
	}
}