
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
}