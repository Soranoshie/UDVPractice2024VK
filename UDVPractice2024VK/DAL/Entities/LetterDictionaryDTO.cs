namespace UDVPractice2024VK.DAL.Entities;

public class LetterDictionaryDTO
{
    public Guid Id { get; set; } = Guid.Empty;
    public char Letter { get; set; } = default;
    public int Count { get; set; }
}