namespace Sk8ter.Infrastructure;

public class ApplicationDbContextInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.EnsureCreated();
    }
}