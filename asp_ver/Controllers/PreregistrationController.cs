using Microsoft.AspNetCore.Mvc;

public class PreregistrationController:Controller {
    private IRepository _repo; 
    public PreregistrationController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Index(){
        DateOnly temp = DateOnly.FromDateTime(DateTime.Now);
        string date = $"{temp.Year.ToString()}-{temp.Month.ToString()}-{temp.Day.ToString()}";
        PreregistrationVM preregVm = new PreregistrationVM(_repo.GetEntries(),                                                   DateOnly.ParseExact(date,"yyyy-MM-dd"));        
        return View(preregVm);
    }
    [HttpPost]
    public IActionResult Index(string date) {
         DateOnly temp = DateOnly.FromDateTime(DateTime.Now);
        date = date is null?$"{temp.Year.ToString()}-{temp.Month.ToString()}-{temp.Day.ToString()}":date;
        PreregistrationVM preregVm = new PreregistrationVM(_repo.GetEntries(),
                                                            DateOnly.ParseExact(date,"yyyy-MM-dd"));        
        return View(preregVm);
    }

    [HttpPost]
    public IActionResult Create(NewEntry newEntry){
        if(newEntry.Ids is null){
            return View("Create",new CreateEntryVM(new(),"Время не выбранно"));
        }
        if(newEntry.Ids.Count() > 1)
        foreach(var i in newEntry.Ids) {
            
            var dt = EntriesFactory.CreateEntryDT(i,newEntry.Date);
            var createdEntry = EntriesFactory.CreateEntry(new EntryProps(newEntry.Owner,
            newEntry.Phone,newEntry.Description,dt));
            _repo.AddEntry(createdEntry);
        }
        else {
            var dt = EntriesFactory.CreateEntryDT(newEntry.Ids[0],newEntry.Date);
            var createdEntry = EntriesFactory.CreateEntry(new EntryProps(newEntry.Owner,
            newEntry.Phone,newEntry.Description,dt));
            _repo.AddEntry(createdEntry);

        }
        return View("Create",new CreateEntryVM(new(),"Запись добавленна"));
    }
}