namespace UDVPractice2024VK.DAL.Entities;

public class PostEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Text { get; set; } = default;
    public int OriginalOrder { get; set; }
}