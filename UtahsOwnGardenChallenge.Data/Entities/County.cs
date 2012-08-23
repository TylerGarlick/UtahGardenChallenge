using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace UtahsOwnGardenChallenge.Data.Entities
{
	public class County : Entity
	{
		public County()
		{
			Cities = new Collection<City>();
		}

		[Required]
		public string Name { get; set; }

		public virtual ICollection<City> Cities { get; set; }
	}
}