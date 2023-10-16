
public class SiteRepository : IRepository
{
    private readonly SiteDbContext _context;
    public SiteRepository(SiteDbContext cont)
    {
        _context = cont;
    }    
    public IQueryable<Entry> GetEntries()
    {
        return _context.Entries;    
    }
    public void AddEntry(Entry entry){
        System.Console.WriteLine(entry);
        _context.Add(entry);
        _context.SaveChanges();
    }

}