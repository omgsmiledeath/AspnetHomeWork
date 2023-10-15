public class PreregistrationVM
{
    private PreregistrationModel preregModel;
    public List<InputEntry> GetInputEntries()=> preregModel.InputEntries;
    public PreregistrationVM(IQueryable<Entry> entries,DateOnly date)
    {
        preregModel = new PreregistrationModel(entries,date);
    }
    
}