var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("https://frontend-test-nu-eight.vercel.app") // tu frontend local
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Usar CORS antes de los endpoints
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
