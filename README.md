# .NetAPI_Cors_Configuration

# 1. Add package Cors: 
dotnet add package Microsoft.AspNetCore.Cors

# 2. Inject Cors service in 'program.cs':

builder.Services.AddCors(options => { options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin() .AllowAnyHeader() .AllowAnyMethod(); }); });

# 3. UseCors in middleware configuration:
app.UseCors("AllowAll");

ALL DONE!