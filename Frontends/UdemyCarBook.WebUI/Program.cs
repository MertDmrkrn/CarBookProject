using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

//JWT package indirildikten sonra eklenen kýsým
//-----
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
	opt.LoginPath = "/Login/Index/"; //hangi sayfadan girilmesi gerektiðini
	opt.LogoutPath = "/Login/LogOut/"; //hangi sayfadan çýkýlmasý gerektiðini
	opt.AccessDeniedPath = "/Pages/AccessDenied/"; //yanlýþ girilen sayfa
	opt.Cookie.SameSite = SameSiteMode.Strict;
	opt.Cookie.HttpOnly = true;
	opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
	opt.Cookie.Name = "CarBookJwt"; //cookie'nin ismi
});
//-----
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.Run();
