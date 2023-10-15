public class PreregistrationVM
{
    private PreregistrationModel preregModel;
    public List<InputEntry> GetInputEntries()=> preregModel.InputEntries;
    public string GetDate => preregModel.Date;
    public void setDate(string date) => preregModel.Date = date;
    public PreregistrationVM(IQueryable<Entry> entries,DateOnly date)
    {
        preregModel = new PreregistrationModel(entries,date);
    }
    
}