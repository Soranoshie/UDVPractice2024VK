using UDVPractice2024VK.DAL;
using UDVPractice2024VK.DAL.Entities;

namespace UDVPractice2024VK.Modules.LetterModule;

public class LetterService : ILetterService
{
    private readonly ApplicationDbContext _context;

    public LetterService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SaveLetterDictionaryAsync(SortedDictionary<char, int> dictionary)
    {
        var entities = dictionary.Select(kv => new LetterDictionaryDTO
        {
            Id = Guid.NewGuid(),
            Letter = kv.Key,
            Count = kv.Value
        }).ToList();

        _context.LetterDictionary.AddRange(entities);
        await _context.SaveChangesAsync();
    }
}