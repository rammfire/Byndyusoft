namespace Applications;

internal class WhatIs
{
    public static bool IsDelimeter(char c)
    {
        if (" =".IndexOf(c) != -1) return true;
        return false;
    }
    public static bool IsOperator(char c)
    {
        if ("+-*/^()".IndexOf(c) != -1) return true;
        else return false;
    }
    public static byte GetPriority(char s)
    {
        switch (s)
        {
            case '(': return 0;
            case ')': return 1;
            case '+': return 2;
            case '-': return 3;
            case '*': return 4;
            case '/': return 4;
            case '^': return 5;
            default: return 6;

        }
    }

}
