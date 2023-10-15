public class InputEntry
{
    public int InputId { get; set; }
    public Entry? ThisEntry {get;set;}
    private bool _isChecked = false;
    public TimeOnly Time ;
    public bool isChecked {get => _isChecked;}
    
    public InputEntry(Entry entry,TimeOnly time,int id)
    {
        InputId = id;
        ThisEntry = entry;
        _isChecked = ThisEntry is null ? false : true;
        Time = time;
    }
}