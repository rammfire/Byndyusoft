using Applications;
using Applications.PrimaryOperation;

namespace Core;
using static System.Console;

public class Program
{
    public static void Main()
    {
        WriteLine("Выражение нужно ввести ниже");
        string buf = ReadLine();

        Calculate calculate = new Calculate(buf);
        WriteLine(calculate.Calc().ToString("g"));

    }
}