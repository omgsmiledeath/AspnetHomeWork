public interface IRepository
{
    IQueryable<Entry> GetEntries();
    void AddEntry(Entry entry);
}