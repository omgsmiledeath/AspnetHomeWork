public interface IRepository
{
    IQueryable<Entry> GetEntries();
}