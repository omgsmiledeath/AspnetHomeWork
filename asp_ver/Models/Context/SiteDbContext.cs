using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

public class SiteDbContext:DbContext
{
    public DbSet<Entry> Entries { get; set; }
    private string _dbPath;
    //CTOR
    public SiteDbContext()
    {
    var folder = Environment.SpecialFolder.LocalApplicationData;
    var path = Environment.GetFolderPath(folder);
    _dbPath = System.IO.Path.Join(path,"SVS.db"); 
    System.Console.WriteLine(_dbPath);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");
    }
}

