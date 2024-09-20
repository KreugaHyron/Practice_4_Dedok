using Practice_4_Dedok;
public static class StringExtensions
{
    public static int SentenceCount(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return 0;
        char[] sentenceEndings = { '.', '!', '?' };
        string[] sentences = text.Split(sentenceEndings, StringSplitOptions.RemoveEmptyEntries);
        return sentences.Length;
    }
}
//2
public static class StringExtensions_1
{
    public static int WordsStartingAndEndingWithSameLetter(this string text_1)
    {
        if (string.IsNullOrWhiteSpace(text_1))
            return 0;
        string[] words = text_1.Split(new[] { ' ', '\t', '\n', '\r', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Count(word => word.Length > 1 &&
        char.ToLower(word.First()) == char.ToLower(word.Last()));
    }
}
class Program
{
    static void Main(string[] args)
    {
        //1
        Console.WriteLine("Task_1: ");
        string text = "Привіт! Як твої справи? Це чудовий день.";
        int count = text.SentenceCount();
        Console.WriteLine($"Кількість речень: {count}");
        Console.WriteLine();
        Console.ReadKey();
        //2
        Console.WriteLine("Task_2: ");
        string text_1 = "Anna has a radar level kayak, but not every word ends the same.";
        int count_1 = text_1.WordsStartingAndEndingWithSameLetter();
        Console.WriteLine($"Кількість слів: {count_1}");
        Console.WriteLine();
        Console.ReadKey();
        //3
        var backpack = new Backpack("Чорний", "Nike", 1.2, 20, 5);

        backpack.ItemAdded += (sender, e) => Console.WriteLine($"Додано: {e.Item}");
        backpack.ItemRemoved += (sender, e) => Console.WriteLine($"Вилучено: {e.Item}");

        var item1 = new Item("Книга", 3);
        var item2 = new Item("Ноутбук", 5);

        if (backpack.CanAddItem(item1))
        {
            backpack.AddItem(item1);
        }

        if (backpack.CanAddItem(item2))
        {
            backpack.AddItem(item2);
        }

        backpack.RemoveItem(item1);
    }
}
