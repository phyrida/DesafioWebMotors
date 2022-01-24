using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DesafioWebMotors.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DesafioWebmotorsContext>
    {
        public DesafioWebmotorsContext CreateDbContext(string[] args)
        {
            string connectionString = "Server=localhost;Port=3306;Database=teste_webmotors;Uid=root;Pwd=Admin357/";
            var optionBuilder = new DbContextOptionsBuilder<DesafioWebmotorsContext>();

            optionBuilder.UseMySql(connectionString, ServerVersion.Parse("5.7.34", Pomelo.EntityFrameworkCore.MySql.Infrastructure.ServerType.MySql));
            return new DesafioWebmotorsContext(optionBuilder.Options);
        }
    }
}
