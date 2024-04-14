using UDVPractice2024VK.DAL.Entities;

namespace UDVPractice2024VK;

public static class LetterCounter
{
    public static SortedDictionary<char, int> CountSortedChars(IEnumerable<PostEntity> posts)
    {
        var result = new SortedDictionary<char, int>();

        foreach (var letter in posts.SelectMany(post => post.Text.ToLower().Where(char.IsLetter)))
        {
            if (result.ContainsKey(letter))
                result[letter]++;
            else
                result.Add(letter, 1);
        }

        return result;
    }
}