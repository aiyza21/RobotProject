using System.Net.Http;

namespace RobotProject.services
{
	public class LocationService
	{
		private readonly HttpClient _httpClient;


			public LocationService(HttpClient client)
		{
			_httpClient = client;

			client.DefaultRequestHeaders.Add("User-Agent", "C# App");
		}


		public async Task<string> GetNearestRiverFromLocation(Location location)
        {
			string APIUrl = $"https://nominatim.openstreetmap.org/search.php?q=water%20near%20{location.LocationName}%20Australia&polygon_geojson=1&format=jsonv2";

			HttpResponseMessage x = await _httpClient.GetAsync(APIUrl);

			return await x.Content.ReadAsStringAsync();
		}
	}
}

