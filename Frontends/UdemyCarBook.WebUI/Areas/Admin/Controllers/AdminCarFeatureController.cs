using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CarFeatureDtos;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{

	[Area("Admin")]
	[Route("Admin/AdminCarFeature")]
	public class AdminCarFeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminCarFeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index/{id}")]
		[HttpGet]
		public async Task<IActionResult> Index(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/CarFeatures?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		[Route("Index/{id}")]
		public async Task<IActionResult> Index(List<ResultCarFeatureByIdDto> resultCarFeatureByIdDto)
		{


			foreach (var item in resultCarFeatureByIdDto)
			{
				if (item.Available)
				{
					var client = _httpClientFactory.CreateClient();
					await client.GetAsync("https://localhost:7095/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);

				}
				else
				{
					var client = _httpClientFactory.CreateClient();
					await client.GetAsync("https://localhost:7095/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
				}
			}
			return RedirectToAction("Index", "AdminCar");

		}

		[Route("CreateCarFeatureByCarId")]
		[HttpGet]
		public async Task<IActionResult> CreateCarFeatureByCarId()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}

	}
}
