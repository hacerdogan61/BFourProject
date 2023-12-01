using System.Reflection;
using System.Text.Json.Serialization;
using Bfour.Core.Repository;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;
using Bfour.Repository;
using Bfour.Repository.Repository;
using Bfour.Repository.UnitOfWorks;
using Bfour.Service.Mapping;
using Bfour.Service.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContex>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContex)).GetName().Name);
    });

});
builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
builder.Services.AddScoped(typeof(IOrderDetailRepository), typeof(OrderDetailRepository));
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));


builder.Services.AddScoped(typeof(IServices<>), typeof(Service<>));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));
builder.Services.AddScoped(typeof(IOrderDetailService), typeof(OrderDetailService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));
builder.Services.AddAutoMapper(typeof(MappingProfile));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

