public class CreateEntryVM
{
    public List<Entry> Entries {get;set;} = new();
    public string Message {get;set;} = String.Empty;
    public string PrevPath {get;set;}

    public CreateEntryVM(List<Entry> entries,string mess,string prevPath)
    {
        this.Entries = entries;
        Message = mess;
        PrevPath=prevPath;
    }
}

