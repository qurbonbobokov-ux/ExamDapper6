using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ApplicationDbContext>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ITimeTableService, TimeTableService>();
builder.Services.AddScoped<IProgressService, ProgressService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();