using Microsoft.AspNetCore.Mvc;

public class PreregistrationController:Controller {
    private IRepository _repo; 
    public PreregistrationController(IRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index(string date) {
         DateOnly temp = new DateOnly();
        date = date is null?$"{temp.ToString()}-{temp.ToString()}-{temp.ToString()}":date;
        PreregistrationVM preregVm = new PreregistrationVM(_repo.GetEntries(),
                                                            DateOnly.ParseExact(date,"yyyy-MM-dd"));        
        return View(preregVm);
    }
}