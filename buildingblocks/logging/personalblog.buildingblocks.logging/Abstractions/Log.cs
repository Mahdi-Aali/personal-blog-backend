namespace personalblog.buildingblocks.logging.Abstractions;

public abstract class Log
{
    public DateTime CreateDate { get; set; }
    public Guid Id { get; set; }
    public string Stack { get; set; }

    protected Log(string stack)
    {
        Id = Guid.NewGuid();
        CreateDate = DateTime.Now;
        Stack = stack;
    }
}
