using Microsoft.AspNetCore.Mvc;

public class PreregistrationController:Controller {
    private PreregistrationVM preregVm;
    public PreregistrationController(IRepository repo)
    {
        preregVm = new PreregistrationVM(repo.GetEntries(),new DateOnly(2023,10,15));        
    }
    public IActionResult Index() => View(preregVm);
}