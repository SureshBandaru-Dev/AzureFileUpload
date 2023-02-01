using Microsoft.EntityFrameworkCore;
public class PostgreSqlContext : DbContext
{
    // protected readonly IConfiguration Configuration;
    // public PostgreSqlContext(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }
    //public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    // {
    //     // connect to postgres with connection string from app settings
    //     options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    // }

    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
    { }   
    public DbSet<Employee> patients { get; set; }
    public DbSet<User> Users { get; set; }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //     base.OnModelCreating(builder);
    // }
    // public override int SaveChanges()
    // {
    //     ChangeTracker.DetectChanges();
    //     return base.SaveChanges();
    // }
}