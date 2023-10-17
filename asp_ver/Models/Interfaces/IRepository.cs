public interface IRepository
{
    Task<ICollection<Entry>> GetEntries(DateOnly date);
    Task AddEntry(Entry entry);
}