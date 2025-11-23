namespace MainCourante.Core.Models;

public class EventEntry
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public string Category { get; set; }
    public string Description { get; set; }
    public string AgentName { get; set; }
    public bool IsLocked { get; set; }
    public string? AttachmentPath { get; set; }
}
