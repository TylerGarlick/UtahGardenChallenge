using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UtahsOwnGardenChallenge.Data.Entities
{
	public class Garden : Entity
	{
		public Garden()
		{
			GardenReasons = new Collection<GardenReason>();
			PlantTypes = new Collection<PlantType>();
		}

		[Required, StringLength(150)]
		public string FirstName { get; set; }

		[Required, StringLength(150)]
		public string LastName { get; set; }
		
		[StringLength(150)]
		public string GardenName { get; set; }
		
		[StringLength(150)]
		public string GroupName { get; set; }

		[Required, StringLength(512)]
		public string Email { get; set; }

		[Required, StringLength(150)]
		public string Address { get; set; }

		
		public City City { get; set; }

		[Required]
		public string CityName { get; set; }

		[Required]
		public string CountyName { get; set; }

		public County County { get; set; }

		[Required, StringLength(50)]
		public string ZipCode { get; set; }

		[Required]
		public virtual GardenSize GardenSize { get; set; }

		[Required]
		public virtual GardenType GardenType { get; set; }

		public virtual ICollection<GardenReason> GardenReasons { get; set; }

		public virtual ICollection<PlantType> PlantTypes { get; set; }

		public bool CanBeContactedByNas { get; set; }
	}
}