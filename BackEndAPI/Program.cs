using BackEndAPI.Models;
using Microsoft.EntityFrameworkCore;

using BackEndAPI.Services.Contract;
using BackEndAPI.Services.Implementation;

using BackEndAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<NACNContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddScoped<IMemberTypeService, MemberTypeService>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyToApp", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    //app.UseSwagger();
    //app.UseSwaggerUI();
}


app.UseCors("PolicyToApp");
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
