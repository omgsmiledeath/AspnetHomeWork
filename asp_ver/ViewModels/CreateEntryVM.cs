public class CreateEntryVM
{
    public List<Entry> Entries {get;set;} = new();
    public string Message {get;set;} = String.Empty;

    public CreateEntryVM(List<Entry> entries,string mess)
    {
        this.Entries = entries;
        Message = mess;
    }
}

