using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PATATAG_PINEZ_LOGIN.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context")
        ?? throw new InvalidOperationException(
            "Connection string 'DELACERNA_LOMERA_LAB_ACT_3_PROEL4W1Context' not found."
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
