using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

// Get the path to the Firebase credentials from the environment variable
string jsonFilePath = Environment.GetEnvironmentVariable("FIRESTORE_CREDENTIALS_PATH");
if (string.IsNullOrEmpty(jsonFilePath))
{
    throw new InvalidOperationException("The environment variable FIRESTORE_CREDENTIALS_PATH is not set.");
}

// Initialize Firebase
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(jsonFilePath),
});

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
