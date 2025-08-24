using Microsoft.EntityFrameworkCore;

namespace ADO_.NET_Lesson_1;

public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=UsersDB;Integrated Security=True;TrustServerCertificate=True;");
    }

}
