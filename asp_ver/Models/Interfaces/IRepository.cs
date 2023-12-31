public interface IRepository
{
    Task<ICollection<Entry>> GetEntries(DateOnly date);
    ICollection<Entry> GetAllEntries();

    Entry? GetEntry(int id);
    Task AddEntry(Entry entry);

    Task RemoveEntry(int id);
    Task UpdateEntry(Entry entry);

}