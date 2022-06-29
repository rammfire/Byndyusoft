namespace Applications;

public class Calculate
{
    public double Counting(string input)
    {
        double result = 0;
        Stack<double> temp = new Stack<double>();
        try
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!WhatIs.IsDelimeter(input[i]) && !WhatIs.IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (WhatIs.IsOperator(input[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i])
                    {
                        case '+':
                            result = b + a;
                            break;
                        case '-':
                            result = b - a;
                            break;
                        case '*':
                            result = b * a;
                            break;
                        case '/':
                            result = b / a;
                            break;
                        case '^':
                            result = Math.Pow(b, a);
                            break;
                    }
                    temp.Push(result);
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибочка вышла!");
            return 0;
        }
        return temp.Peek();
    }


}
