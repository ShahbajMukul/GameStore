


using Frontend.Clients;
using Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddRazorComponents();

// Client Side Interactivity enabled
builder.Services.AddRazorComponents().
                AddInteractiveServerComponents();


// We use one instance of the client for the whole application so that we can add/ modify the games list from any component
builder.Services.AddSingleton<GamesClients>();

builder.Services.AddSingleton<GenreClient>();

builder.Services.AddSingleton<GameReviewClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// app.MapRazorComponents<App>();

// Enables Server Side Interactivity
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
