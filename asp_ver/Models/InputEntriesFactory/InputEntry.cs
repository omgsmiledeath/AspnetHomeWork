public class InputEntry
{
    public Entry? ThisEntry {get;set;}
    private bool _isChecked = false;
    public TimeOnly Time ;
    public bool isChecked {get => _isChecked;}
    
    public InputEntry(Entry entry,TimeOnly time)
    {
        ThisEntry = entry;
        _isChecked = ThisEntry is null ? false : true;
        Time = time;
    }
}