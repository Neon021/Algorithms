using System.Threading.Channels;

public class Codewars
{
    public static void Main(string[] args)
    {
        Decode(Encode(new() { "furkan","bilal","yigit","güzel",})).ForEach(Console.WriteLine);
    }
    public static string Encode(List<string> strs)
    {
        return string.Concat(strs.SelectMany(s => $"{s.Length}#{s}"));
    }
    
    public static List<string> Decode(string input)
    {
        List<string> strings = new();
        int index = 0;
        while (index < input.Length)
        {
            string lengthStr = string.Empty;
            while (input[index] != '#')
            {
                lengthStr += input[index];
                index++;
            }
            index++;
            _ = int.TryParse(lengthStr, out int length);
            
            string decoded = input.Substring(index, length);
            strings.Add(decoded);
            index += length;
        }

        return strings;
    }
}