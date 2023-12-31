public class PreregistrationModel
{
    public List<InputEntry> InputEntries {get;set;} = new();
    public string Date { get; set; }
    public PreregistrationModel(ICollection<Entry> entries,DateOnly date)
    {
        createInputEntries(entries,date);
        Date=$"{date.Year.ToString()}-{date.Month.ToString()}-{date.Day.ToString()}";
    }

    private void createInputEntries (ICollection<Entry> entries,DateOnly date){
        // var thisDateEntries = entries.Where(e => (e.Date.Day==date.Day)
        //                              &&(e.Date.Month==date.Month)
        //                              &&(e.Date.Year==date.Year)).OrderBy(e => e.Date);
        int count =1;
        for (int i =10;i<23;i++){
            var curTime = new TimeOnly(i,0);
            var filtrEntry = entries.SingleOrDefault(e => e.Date.Hour == curTime.Hour);
            InputEntries.Add(InputEntriesFC.CreateInputEntry(filtrEntry,curTime,count++));
        }
    }
    
}