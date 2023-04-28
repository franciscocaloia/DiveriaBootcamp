using Microsoft.EntityFrameworkCore;

namespace webapi2.Data
{
    public class AhorcadoDBContext : DbContext
    {
        public AhorcadoDBContext(DbContextOptions<AhorcadoDBContext> options) : base(options)
        {

        }
    }
}