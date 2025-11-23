using Microsoft.EntityFrameworkCore;
using MainCourante.Core.Models;

namespace MainCourante.Data;

public class MainCouranteDbContext : DbContext
{
    public DbSet<EventEntry> Events { get; set; }
    public DbSet<User> Users { get; set; }

    private readonly string _dbPath;

    public MainCouranteDbContext()
    {
        var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MainCourante");
        Directory.CreateDirectory(folder);
        _dbPath = Path.Combine(folder, "maincourante.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");
}
