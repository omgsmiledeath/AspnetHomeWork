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
    public IActionResult Entries(int entryId=0) {
        if (entryId == 0) return View("Entries",_repo.GetAllEntries()); 
        var entry = _repo.GetEntry(entryId);
        if(entry is null){
            return View("Create",CreateEntryVMF.Create("Такой записи нет","/Preregistration/"));
        }
        else {
            return View("Entries",new List<Entry>(){entry});
        }
    }

    [HttpPost]
    public async Task<IActionResult> EntryEdit(int Id,string Owner,string Description,string Date,string Phone){
        var dt = DateTime.Parse(Date);
        await _repo.UpdateEntry(new Entry(){Id=Id,Owner=Owner,Description=Description,Phone=Phone,Date=dt});
        return View("Create",CreateEntryVMF.Create($"Запись отредактированна","/Preregistration/Entries"));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteEntry(int Id){
        await _repo.RemoveEntry(Id);
        return View("Create",CreateEntryVMF.Create($"Запись удаленна","/Preregistration/Entries"));

    }
    [HttpPost]
    public async Task<IActionResult> Create(NewEntry newEntry){
        if(newEntry.Ids is null){
            return View("Create",CreateEntryVMF.Create("Время не выбранно","/Preregistration/"));
        }
        var newEntries = new List<Entry>();
        if(newEntry.Ids.Count() > 1)
        foreach(var i in newEntry.Ids) {
            newEntries.Add(await entriyToBase(newEntry.Date,i,newEntry.Owner,newEntry.Phone,newEntry.Description));
        }
        else {
            newEntries.Add(await entriyToBase(newEntry.Date,newEntry.Ids[0],newEntry.Owner,newEntry.Phone,newEntry.Description));

        }
        return View("Create",CreateEntryVMF.Create(newEntries,"Запись добавленна","/Preregistration/"));
    }
    private async Task<Entry> entriyToBase (string Date,int id,string Owner="Guest",string Phone="unknown",string Description="Ничего"){
            var dt = EntriesFactory.CreateEntryDT(id,Date);
            var createdEntry = EntriesFactory.CreateEntry(new EntryProps(Owner,
            Phone,Description,dt));
           await _repo.AddEntry(createdEntry);
            return createdEntry;
    }
}