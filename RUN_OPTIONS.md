# Ways to Run the Commander API

## Option 1: Run from API Project Directory
```bash
cd Commander.API
dotnet run
```

## Option 2: Run from Root Directory (Recommended)
```bash
dotnet run --project Commander.API
```

## Option 3: Using Solution File
```bash
dotnet build Commander.sln
dotnet run --project Commander.API
```

## Option 4: Using Visual Studio
- Open `Commander.sln` in Visual Studio
- Set `Commander.API` as the startup project
- Press F5 or click Run

## Option 5: Using dotnet watch (for development)
```bash
# From root directory
dotnet watch run --project Commander.API

# From API directory
cd Commander.API
dotnet watch run
```

## Testing the API
- HTTP: http://localhost:5000/api/commands
- HTTPS: https://localhost:5001/api/commands
- Swagger UI: http://localhost:5000/swagger

## Fixed Issues
1. ✅ AutoMapper configuration issue resolved
2. ✅ Can now run from root directory
3. ✅ API endpoints working correctly
