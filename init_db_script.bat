dotnet ef migrations add InitialData --context DataContext --project DAL\DAL.Context\DAL.Context.csproj
dotnet ef database update --context DataContext --project DAL\DAL.Context\DAL.Context.csproj
PAUSE