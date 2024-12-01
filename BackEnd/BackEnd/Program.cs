using BidNest.Data;
using BidNest.Services;
using Microsoft.EntityFrameworkCore;
// using sib_api_v3_sdk.Client;
// using EmailSender = Sendinblue.EmailSender;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<AuctionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// // Set your API key
// Configuration.Default.ApiKey.Add("api-key", "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");

// // Call the SendEmail method
// EmailSender.SendEmail(
//     senderName: "BidNest",
//     senderEmail: "kavishen1025@gmail.com",
//     receiverEmail: "hajel32179@scarden.com",
//     receiverName: "bidder.UserName", // Assuming you have a UserName property in your User model
//     subject: "You won the auction!",
//     message: $"<html><body><h1>Congratulations! You won the auction for good.</h1></body></html>"
// );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSession(); // Enable session
app.UseAuthorization();

app.MapControllers();

app.Run();
