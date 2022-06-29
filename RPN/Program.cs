using Applications;
using static System.Console;
namespace ReversePolish;

public class Program
{
    public static void Main()
    {
        CheckingCharacters checkingCharacters = new CheckingCharacters();
        Console.WriteLine(checkingCharacters.CheckValue("+5"));
    }
}