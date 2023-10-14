using Microsoft.EntityFrameworkCore;
public class Entry
{
    public int Id { get; set; }
    public string Owner { get; set; }
    public DateTime Date { get; set; }
    public string Phone { get; set; }
    public bool? IsCymbals { get; set; }
    public string? Description {get;set;}
}