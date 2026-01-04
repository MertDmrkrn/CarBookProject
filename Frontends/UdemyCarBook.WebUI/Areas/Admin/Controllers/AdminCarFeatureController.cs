using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CarFeatureDtos;

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
		[Route("Index")]
		public async Task<IActionResult> Index(List<ResultCarFeatureByIdDto> resultCarFeatureByIdDto)
		{
			foreach (var item in resultCarFeatureByIdDto)
			{
				if (item.Available)
				{
					var client = _httpClientFactory.CreateClient();
					var jsonData = JsonConvert.SerializeObject(resultCarFeatureByIdDto);
					StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
					var responseMessage = await client.PutAsync();
					return RedirectToAction("Index", "AdminCar");
				}
				else
				{

				}
			}
			return View();

		}
	}
}
