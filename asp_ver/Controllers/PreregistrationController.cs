using Microsoft.AspNetCore.Mvc;

public class PreregistrationController:Controller {
    private IRepository _repo; 
    public PreregistrationController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Index(){
        DateOnly temp = DateOnly.FromDateTime(DateTime.Now);
        string date = $"{temp.Year.ToString()}-{temp.Month.ToString()}-{temp.Day.ToString()}";
        PreregistrationVM preregVm = new PreregistrationVM(await _repo.GetEntries(temp), DateOnly.ParseExact(date,"yyyy-MM-dd"));        
        return View(preregVm);
    }
    [HttpPost]
    public async Task<IActionResult> Index(string date) {
         DateOnly temp = DateOnly.FromDateTime(DateTime.Now);
        date = date is null?$"{temp.Year.ToString()}-{temp.Month.ToString()}-{temp.Day.ToString()}":date;
        var notStrDate =  DateOnly.ParseExact(date,"yyyy-MM-dd");
        PreregistrationVM preregVm = new PreregistrationVM(await _repo.GetEntries(notStrDate),
                                                            DateOnly.ParseExact(date,"yyyy-MM-dd")); 

        return View(preregVm);
    }
    [HttpGet]
    public IActionResult Entries() => View("Entries",_repo.GetAllEntries());
    [HttpPost]
    public IActionResult Entries(int entryId) {
        var entry = _repo.GetEntry(entryId);
        System.Console.WriteLine(entry is null);
        if(entry is null){
            return View("Create",new CreateEntryVM(null,"Такой записи нет"));
        }
        else {
            return View("Entries",new List<Entry>(){entry});
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create(NewEntry newEntry){
        if(newEntry.Ids is null){
            return View("Create",new CreateEntryVM(new(),"Время не выбранно"));
        }
        var newEntries = new List<Entry>();
        if(newEntry.Ids.Count() > 1)
        foreach(var i in newEntry.Ids) {
            newEntries.Add(await entriyToBase(newEntry.Date,newEntry.Owner,newEntry.Phone,newEntry.Description,i));
        }
        else {
            newEntries.Add(await entriyToBase(newEntry.Date,newEntry.Owner,newEntry.Phone,newEntry.Description,newEntry.Ids[0]));

        }
        return View("Create",new CreateEntryVM(newEntries,"Запись добавленна"));
    }
    private async Task<Entry> entriyToBase (string Date,string Owner,string Phone,string Description,int id){
            var dt = EntriesFactory.CreateEntryDT(id,Date);
            var createdEntry = EntriesFactory.CreateEntry(new EntryProps(Owner,
            Phone,Description,dt));
           await _repo.AddEntry(createdEntry);
            return createdEntry;
    }
}