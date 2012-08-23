using UtahsOwnGardenChallenge.Repositories.Entities.ZipCodes;

namespace UtahsOwnGardenChallenge.Repositories
{
	public interface IZipCodeRepository
	{
		ZipCode GetZipcode(string zipcode);
	}
}