using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NLayer.Repository;
using NLayer.Service.Mapping;
using NLayer.Web.Modules;
using System.Reflection;
using FluentValidation.AspNetCore;
using NLayer.Service.Validations;
using NLayer.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>()); ;

builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));



builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name);
    });
});

builder.Services.AddScoped(typeof(NotFoundFilter<>));

//https://stackoverflow.com/questions/69754985/adding-autofac-to-net-core-6-0-using-the-new-single-file-template
//There is no argument given that corresponds to the required formal parameter 'lifetime Scope' of ' Hatas�n�n ��z�m� yukar�da yer alan link
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new RepoServiceModule());
    });
var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
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
