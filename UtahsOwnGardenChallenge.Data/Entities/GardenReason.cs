using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UtahsOwnGardenChallenge.Data.Entities
{
	public class GardenReason : Entity
	{
		public GardenReason()
		{
			Gardens = new Collection<Garden>();
		}

		public ICollection<Garden> Gardens { get; set; }
		[Required, StringLength(150)]
		public string Name { get; set; }
	}
}