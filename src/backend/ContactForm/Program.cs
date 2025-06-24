using ContactForm.Services;
using ContactForm.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<EmailSettings>(
builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<EmailService>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuración del encabezado
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "frame-ancestors 'self' http://localhost:4200 https://rjsanndoval.com;");
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// CORS (opcional, si usas desde frontend externo como Angular)
app.UseCors("AllowAll");

// Redirige a HTTPS si llega una solicitud por HTTP
app.UseHttpsRedirection();

// Sirve archivos estáticos (CSS, JS, imágenes)
app.UseStaticFiles();

// Routing (enruta a Razor Pages o Controllers)
app.UseRouting();

// Autorización (si usas [Authorize] en algún endpoint)
app.UseAuthorization();

// Razor Pages
app.MapRazorPages();

// API Controllers
app.MapControllers();

// Inicia la aplicación
app.Run();
