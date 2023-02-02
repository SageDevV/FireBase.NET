using FireBaseServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var fireBaseRepository = new FireBaseRepository();

app.MapPost("firebaseserver/{id}", (int id) => fireBaseRepository.FireBaseService(id));

app.Run();
