using System;
using System.ComponentModel.DataAnnotations;

namespace UtahsOwnGardenChallenge.Data.Entities
{
	public class Entity
	{
		public Entity()
		{
			Id = Guid.NewGuid();
			CreatedOn = DateTime.UtcNow;
		}

		[Key]
		public Guid Id { get; set; }

		[Required]
		public DateTime CreatedOn { get; set; }
		public DateTime? UpdatedOn { get; set; }
	}
}