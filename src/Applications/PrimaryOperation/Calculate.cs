using static Applications.AllOperation.Operations;

namespace Applications.PrimaryOperation;

public class Calculate
{
    private string source;     // исходная строчка
    private int pos;        // текущая позиция
    public Calculate(string s)
    {
        source = s;
    }

    public float Calc()
    {
        pos = 0;
        Operation root = AdditionOrSubtraction();
        return (root != null) ? root.Eval() : 0.0f;
    }

    // Низкий приоритет: сложение, вычитание
    private Operation AdditionOrSubtraction()
    {
        Operation result = MultiplicationOrDivision();

        for (; ; )
        {
            if (Match('+')) result = new Plus(result, MultiplicationOrDivision());
            else if (Match('-')) result = new Minus(result, MultiplicationOrDivision());
            else return result;
        }
    }

    // Средний приоритет: умножение, деление
    private Operation MultiplicationOrDivision()
    {
        Operation result = Staples();
        for (; ; )
        {
            if (Match('*')) result = new Multiply(result, Staples());
            else if (Match('/')) result = new Divide(result, Staples());
            else return result;
        }
    }

    // Высокий приоритет: одинокий минус, скобки, число
    private Operation Staples()
    {
        Operation result = null;

        if (Match('-'))
        {
            result = new Negation(AdditionOrSubtraction());
        }
        else if (Match('('))
        {
            result = AdditionOrSubtraction();
            if (!Match(')'))
                Console.WriteLine("Утеряно ')'");
        }
        else
        {
            // Разбираю число
            float val = 0.0f;
            int start = pos;
            while (pos < source.Length && (char.IsDigit(source[pos]) || source[pos] == '.' || source[pos] == 'e')) ++pos;

            try { val = float.Parse(source.Substring(start, pos - start)); }
            catch { System.Console.WriteLine("Невозможно разобрать '" + source.Substring(start) + "'"); }
            result = new Number(val);

        }
        return result;
    }

    // Поищем символ в строке
    private bool Match(char ch)
    {
        if (pos >= source.Length) return false;
        while (source[pos] == ' ') ++pos;             // пропустим пробелы

        if (source[pos] == ch) { ++pos; return true; } // нашли что искали?
        else return false;
    }
}