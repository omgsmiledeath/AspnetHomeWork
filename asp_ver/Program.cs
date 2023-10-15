var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SiteDbContext>();
builder.Services.AddScoped<IRepository,SiteRepository>();

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
SeedData.AddData(app);
app.Run();
