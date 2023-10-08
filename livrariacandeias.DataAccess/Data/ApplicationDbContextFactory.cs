
using livrariacandeias.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

{
    public ApplicationDbContext CreateDbContext(string[] args)

    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=livrariacandeias; Trusted_Connection=True; TrustServerCertificate=True");

        return new ApplicationDbContext(optionsBuilder.Options);
    }

}