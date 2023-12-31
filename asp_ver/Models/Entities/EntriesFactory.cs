public static class EntriesFactory
{
    public static Entry CreateEntry(EntryProps props){
        return new Entry{
            Owner = props.Owner,
            Description = props.Description,
            Date = props.Date,
            Phone = props.Phone
        };
    }
    public static string createInputDate(DateTime date){
        return $"{date.Year.ToString()}-{charCheck(date.Month)}-{charCheck(date.Day)}T{charCheck(date.Hour)}:{charCheck(date.Minute)}";
    }

    private static string charCheck(int n){
        if(n.ToString().Length==1) return $"0{n}";
        else return n.ToString();
    }
    public static DateTime CreateEntryDT (int inputId,string dateOnly){
       var yMd =  DateOnly.ParseExact(dateOnly,"yyyy-MM-dd");
       var hm = TimeIds[inputId];
        return new DateTime(yMd.Year,yMd.Month,yMd.Day,hm.Hour,hm.Minute,0);
    }
    private static Dictionary<int,TimeOnly> TimeIds = new Dictionary<int,TimeOnly>{
    {1,new TimeOnly(10,0)},
    {2,new TimeOnly(11,0)},
    {3,new TimeOnly(12,0)},
    {4,new TimeOnly(13,0)},
    {5,new TimeOnly(14,0)},
    {6,new TimeOnly(15,0)},
    {7,new TimeOnly(16,0)},
    {8,new TimeOnly(17,0)},
    {9,new TimeOnly(18,0)},
    {10,new TimeOnly(19,0)},
    {11,new TimeOnly(20,0)},
    {12,new TimeOnly(21,0)},
    {13,new TimeOnly(22,0)},

};
}

public record EntryProps (string Owner,string Phone,string Description,DateTime Date);
