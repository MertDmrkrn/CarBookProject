using Microsoft.AspNetCore.SignalR;

namespace CarBookProject.WebApi.Hubs
{
	public class CarHub : Hub
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CarHub(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task SendCarCount()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCount");
			var values = await responseMessage.Content.ReadAsStringAsync();
			await Clients.All.SendAsync("ReceiveCarCount", values);
		}

	}
}
