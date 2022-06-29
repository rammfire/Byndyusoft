namespace Applications;

public class CheckingCharacters
{
    public string CheckValue(string input)
    {
        string output = string.Empty;
        char[] chars = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+', '-', '*', '/', '^', '(', ')' };
        bool symbolExist = false;
        try
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[0] == '-' || input[0] == '+' || input[0] == '*' || input[0] == '/')
                {
                    return $"Извинете. Знак '{input[0]}' не может быть в начале";
                }
                if (WhatIs.IsDelimeter(input[i]) || WhatIs.IsOperator(input[i]) || char.IsDigit(input[i]))
                    output += input[i];
                else continue;
                
                for (int j = 0; j < chars.Length; j++)
                {
                    if (chars[j] == input[i])
                    {
                        symbolExist = true;
                    }

                };
            }

            if (!symbolExist) { return "Присутствует неверный символ"; }
        }
        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return output;
    }
}
