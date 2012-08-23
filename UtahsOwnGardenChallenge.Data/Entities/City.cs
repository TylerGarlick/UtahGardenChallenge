using System.ComponentModel.DataAnnotations;

namespace UtahsOwnGardenChallenge.Data.Entities
{
	public class City : Entity
	{
		[Required]
		public virtual County County { get; set; }

		[Required]
		public string Name { get; set; }

		public float? Longitude { get; set; }
		public float? Latitude { get; set; }
	}
}