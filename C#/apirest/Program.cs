var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMvc();
app.MapGet("/", () => "Ahre!");
app.MapControllers();
app.Run();
