using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PATATAG_PINEZ_LOGIN.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PATATAG_PINEZ_LOGINContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PATATAG_PINEZ-LOGINContext")
        ?? throw new InvalidOperationException(
            "Connection string 'PATATAG_PINEZ-LOGINContext' not found."
        )
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();