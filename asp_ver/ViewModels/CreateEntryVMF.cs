public static class CreateEntryVMF
{
    public static CreateEntryVM Create(string message,string prevPath="/"){
        return new CreateEntryVM(new(),message,prevPath);
    }
    public static CreateEntryVM Create(List<Entry> entries,string message,string prevPath="/"){
        return new CreateEntryVM(entries,message,prevPath);
    }
}