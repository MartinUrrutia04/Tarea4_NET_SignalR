using Tarea_4_SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//agrego servicio 
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<LoginConVerificacionHub>("/login");

app.MapGet("/verificar/usuario/{userId}", (string userId, 
    ILogger < LoginConVerificacionHub > logger, 
    IHubContext < LoginConVerificacionHub> hubContext) => {
    
    // Se notifica al cliente con id {userId}    
    logger.LogInformation($"Se notificara al cliente con id {userId}");

    // Esta es la forma de enviar a todos los clientes conectados
    //hubContext.Clients.All.SendAsync("VerificacionOk", userId); pero no se si es necesario

    // Esta es la forma de enviar a un cliente específico
    hubContext.Clients.Client(userId).SendAsync("VerificacionOk", userId);


});

app.Run();
