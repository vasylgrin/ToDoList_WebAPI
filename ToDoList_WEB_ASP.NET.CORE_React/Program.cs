namespace ToDoList_WEB_ASP.NET.CORE_React
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller}/{action=Index}/{id?}");

            //app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}