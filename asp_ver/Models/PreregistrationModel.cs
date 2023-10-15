public class PreregistrationModel
{
    public List<InputEntry> InputEntries {get;set;} = new();

    public PreregistrationModel(IQueryable<Entry> entries,DateOnly date)
    {
        createInputEntries(entries,date);
    }

    private void createInputEntries (IQueryable<Entry> entries,DateOnly date){
        var thisDateEntries = entries.Where(e => (e.Date.Day==date.Day)
                                     &&(e.Date.Month==date.Month)
                                     &&(e.Date.Year==date.Year)).OrderBy(e => e.Date);
        for (int i =10;i<23;i++){
            var curTime = new TimeOnly(i,0);
            var filtrEntry = thisDateEntries.SingleOrDefault(e => e.Date.Hour == curTime.Hour);
            InputEntries.Add(InputEntriesFC.CreateInputEntry(filtrEntry,curTime));
        }
    }
    
}