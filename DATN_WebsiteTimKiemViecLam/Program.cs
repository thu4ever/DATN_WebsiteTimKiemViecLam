using DATN_WebsiteTimKiemViecLam.Models;
using DATN_WebsiteTimKiemViecLam.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddTransient<TakePictureFromPdf>();
builder.Services.AddDbContext<db_WebsiteTimkiemvieclamContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Doanhnghiep}/{action=hienthidanhsachbaidang}");

app.Run();
