Dictionary<string, Func<int, int, int>> diadicFunctions = new Dictionary<string, Func<int, int, int>>
{
    { "+", (a, b) => a + b },
    { "-", (a, b) => a - b },
    { "/", (a, b) => a / b },
    { "*", (a, b) => a * b }
};

Dictionary<string, Func<int, int>> monadicFunctions = new Dictionary<string, Func<int, int>>
{
    { "?", a=> {Console.WriteLine(a); return a; } },
    { "nop", x=>x }

};


parseInput(Console.ReadLine());


void parseInput(string input)
{
    Stack<int> openBrackets = new Stack<int>();

    for (int i = 0; i < input.Length; i++)
    {
        if (input[i] == '(')
        {
            openBrackets.Push(i);
        }

        if (input[i] == ')')
        {
            int firstBracket = openBrackets.Peek();
            string statement = input.Substring(firstBracket + 1, i- firstBracket - 1);
            input = input.Remove(firstBracket, i - firstBracket + 1);
            input = input.Insert(firstBracket, parseStatement(statement) + "");
            i= openBrackets.Pop();
        }
    }
}

int parseStatement(string statement)
{
    string[] components = statement.Split(" ");
    string op = components.Length > 0 ? components[0] : "?";
    int alpha = components.Length > 1 ? int.Parse(components[1]) : -1;
    int omega = components.Length > 2 ? int.Parse(components[2]) : -1;
    if (monadicFunctions.ContainsKey(op))
    {
        return monadicFunctions[op](alpha);
    }
    if (diadicFunctions.ContainsKey(op))
    {
        return diadicFunctions[op](alpha, omega);
    }
    return -1;
}
