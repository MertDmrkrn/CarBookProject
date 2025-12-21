using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.RentACarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
	public class RentACarListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RentACarListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int locationID)
		{
			
			var locationid = TempData["locationid"];

			//filterRentACarDto.locationID = int.Parse(locationid.ToString());
			//filterRentACarDto.available = true;
			locationID = int.Parse(locationid.ToString());
			ViewBag.locationid = locationid;


			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7095/api/RentACars?locationID={locationID}&available=true");
			if (responseMessage.IsSuccessStatusCode) 
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
