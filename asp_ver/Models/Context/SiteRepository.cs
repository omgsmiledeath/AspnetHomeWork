
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

    public async Task RemoveEntry(int id)
    {
        var entry = await _context.Entries.SingleAsync(e=>e.Id==id);
        if(entry is not null) _context.Remove(entry);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEntry(Entry entry)
    {
        var baseEntry = _context.Entries.Update(entry);
        await _context.SaveChangesAsync();
    }
}