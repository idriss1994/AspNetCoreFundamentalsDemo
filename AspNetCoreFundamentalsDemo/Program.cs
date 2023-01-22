using AspNetCoreFundamentalsDemo;
using AspNetCoreFundamentalsDemo.Services;
using AspNetCoreFundamentalsDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register groups of services with extension custom methods
builder.Services.AddMyDependencyGroup()
    .AddConfig(builder.Configuration);

builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();

// Services not created by the service container:
builder.Services.AddSingleton(new Service1());
builder.Services.AddSingleton(new Service2());

var myKey = builder.Configuration["MyKey"];
builder.Services.AddSingleton<IService3>(sp => new Service3(myKey));


var app = builder.Build();

// Resolve a service at app start up
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var myDependency = serviceProvider.GetRequiredService<IMyDependency>();
    myDependency.WriteMessage("Call service form main");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Custom middleware
app.UseMyMiddleware();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
