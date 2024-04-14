namespace UDVPractice2024VK.Modules.LetterModule;

public interface ILetterService
{
    Task SaveLetterDictionaryAsync(SortedDictionary<char, int> dictionary);
}
