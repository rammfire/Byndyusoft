namespace Applications;

public class ExpressionConverter
{
    /// <summary>
    /// метод преобразовывает входящую строку
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string Expression(string input)
    {
        string output = string.Empty;
        Stack<char> operStack = new Stack<char>();
        for (int i = 0; i < input.Length; i++)
        {
            if (WhatIs.IsDelimeter(input[i]))
                continue;
            if (char.IsDigit(input[i]))
            {
                while (!WhatIs.IsDelimeter(input[i]) && !WhatIs.IsOperator(input[i]))
                {
                    output += input[i];
                    i++;
                    if (i == input.Length) break;
                }
                output += " ";
                i--;
            }
            if (WhatIs.IsOperator(input[i]))
            {
                if (input[i] == '(')
                    operStack.Push(input[i]);
                else if (input[i] == ')')
                {
                    char s = operStack.Pop();
                    while (s != '(')
                    {
                        output += s.ToString() + ' ';
                        s = operStack.Pop();
                    }
                }
                else
                {
                    if (operStack.Count > 0)
                        if (WhatIs.GetPriority(input[i]) <= WhatIs.GetPriority(operStack.Peek()))
                            output += operStack.Pop().ToString() + " ";
                    operStack.Push(char.Parse(input[i].ToString()));
                }
            }
        }
        while (operStack.Count > 0)
        {
            output += operStack.Pop() + " ";
        }
        return output;
    }
}
