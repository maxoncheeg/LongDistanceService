namespace LongDistanceService.Data.Entities.Identity;

public class MenuTabRight
{
    public int UserId { get; set; }
    public int MenuTabId { get; set; }
    public bool R { get; set; }
    public bool W { get; set; }
    public bool E { get; set; }
    public bool D { get; set; }

    public MenuTab MenuTab { get; set; } = null!;
    public User User { get; set; } = null!;
}