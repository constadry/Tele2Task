namespace Tele2Task.Models;

public class UserParameters
{
    private int _pageSize = 13;
    private const int MaxPageSize = 13;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public string? Sex { get; set; }
    
    public int Age { get; set; }
}