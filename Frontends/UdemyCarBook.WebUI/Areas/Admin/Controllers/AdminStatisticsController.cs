using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminStatistics")]
	public class AdminStatisticsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AdminStatisticsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{

			var client = _httpClientFactory.CreateClient();

			#region İstatistik1
			var responseMessage = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
				ViewBag.carCount = values.carCount;
			}
			#endregion

			#region İstatistik2
			var responseMessage2 = await client.GetAsync("https://localhost:7095/api/Statistics/GetLocationCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
				ViewBag.locationCount = values2.locationCount;
			}
			#endregion

			#region İstatistik3
			var responseMessage3 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAuthorCount");
			if (responseMessage3.IsSuccessStatusCode)
			{
				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
				ViewBag.authorCount = values3.authorCount;
			}
			#endregion

			#region İstatistik4
			var responseMessage4 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBlogCount");
			if (responseMessage4.IsSuccessStatusCode)
			{
				var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
				var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
				ViewBag.blogCount = values4.blogCount;
			}
			#endregion

			#region İstatistik5
			var responseMessage5 = await client.GetAsync("https://localhost:7095/api/Statistics/GetBrandCount");
			if (responseMessage5.IsSuccessStatusCode)
			{
				var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
				var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
				ViewBag.brandCount = values5.brandCount;
			}
			#endregion

			#region İstatistik6
			var responseMessage6 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAvgRentPriceForDaily");
			if (responseMessage6.IsSuccessStatusCode) 
			{
				var jsonData6=await responseMessage6.Content.ReadAsStringAsync();
				var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
				ViewBag.avgRentPriceForDaily = values6.avgRentPriceForDaily.ToString("0.00");
			}
			#endregion

			#region İstatistik7
			var responseMessage7 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAvgRentPriceForWeekly");
			if (responseMessage7.IsSuccessStatusCode) 
			{
				var jsonData7=await responseMessage7.Content.ReadAsStringAsync();
				var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
				ViewBag.avgRentPriceForWeekly = values7.avgRentPriceForWeekly.ToString("0.00");
			}
			#endregion

			#region İstatistik8
			var responseMessage8 = await client.GetAsync("https://localhost:7095/api/Statistics/GetAvgRentPriceForMonthly");
			if (responseMessage8.IsSuccessStatusCode) 
			{
				var jsonData8=await responseMessage8.Content.ReadAsStringAsync();
				var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
				ViewBag.GetAvgRentPriceForMonthly = values8.avgRentPriceForMonthly.ToString("0.00");
			}
			#endregion

			#region İstatistik9
			var responseMessage9 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByTransmissionIsAuto");
			if (responseMessage9.IsSuccessStatusCode) 
			{
				var jsonData9=await responseMessage9.Content.ReadAsStringAsync();
				var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
				ViewBag.carCountByTransmissionIsAuto = values9.carCountByTransmissionIsAuto;
			}
			#endregion

			#region İstatistik10
			var responseMessage10 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByKmSmallerThen1000");
			if (responseMessage10.IsSuccessStatusCode) 
			{
				var jsonData10=await responseMessage10.Content.ReadAsStringAsync();
				var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
				ViewBag.carCountByKmSmallerThen1000 = values10.carCountByKmSmallerThen1000;
			}
			#endregion

			#region İstatistik11
			var responseMessage11 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
			if (responseMessage11.IsSuccessStatusCode) 
			{
				var jsonData11=await responseMessage11.Content.ReadAsStringAsync();
				var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
				ViewBag.carCountByFuelGasolineOrDiesel = values11.carCountByFuelGasolineOrDiesel;
			}
			#endregion

			#region İstatistik12
			var responseMessage12 = await client.GetAsync("https://localhost:7095/api/Statistics/GetCarCountByFuelElectric");
			if (responseMessage12.IsSuccessStatusCode) 
			{
				var jsonData12=await responseMessage12.Content.ReadAsStringAsync();
				var values12=JsonConvert.DeserializeObject<ResultStatisticsDto> (jsonData12);
				ViewBag.carCountByFuelElectric = values12.carCountByFuelElectric;
			}
			#endregion
			return View();
		}
	}
}
