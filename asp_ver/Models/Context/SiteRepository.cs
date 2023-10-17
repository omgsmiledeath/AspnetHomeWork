
using System.Collections;
using Microsoft.EntityFrameworkCore;

public class SiteRepository : IRepository
{
    private readonly SiteDbContext _context;
    public SiteRepository(SiteDbContext cont)
    {
        _context = cont;
    }    
    public async Task<ICollection<Entry>> GetEntries(DateOnly date)
    {
        return await _context.Entries.Where(e=>
        (e.Date.Year==date.Year)&&(e.Date.Month==date.Month)&&(e.Date.Day==date.Day))
        .OrderBy(e => e.Date)
        .ToArrayAsync();  
        //return await _context.Entries.ToArrayAsync();
    }
    public Task AddEntry(Entry entry){

        return Task.Run( async ()=> {
            //if(_context.Entries.Where(e=> e.Date == entry.Date) == null){
            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();
            //}
        });
    }
    public Entry? GetEntry(int id){
        return _context.Entries.SingleOrDefault(e=>e.Id == id);
    }

    public ICollection<Entry> GetAllEntries()
    {
        return _context.Entries.ToList();
    }
}