using System.Text;

public class Codewars
{
    public static void Main(string[] args)
    {
        MaximumOddBinaryNumber("010010101010100");
    }
    public static string MaximumOddBinaryNumber(string s)
    {
        //int numberOfOne = s.Count(x => x == '1');
        //StringBuilder sb = new();
        //for (int i = 0; i < numberOfOne - 1; i++)
        //{
        //    sb.Append('1');
        //}
        //for (int i = 0; i < s.Length - numberOfOne; i++)
        //{
        //    sb.Append('0');
        //}
        //sb.Append('1');
        //return sb.ToString();
        int count = s.Count(x => x == '1');
        String? rs = new string('1', count - 1) + new string('0', s.Length - count) + new string('1', 1);
        return rs;
    }
}