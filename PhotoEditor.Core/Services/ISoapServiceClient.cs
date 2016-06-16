using System.Threading.Tasks;

namespace PhotoEditor.Core.Services
{
	public interface ISoapServiceClient
	{
		Task<string> GetWeather(string city, string country);
	}
}