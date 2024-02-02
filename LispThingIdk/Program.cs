using LispThingIdk;
using static LispThingIdk.Evaluater;

ListElement list = new ListElement();
int i;




// TODO: make this not while true
while (true)
{
    i = 0;
    list = parseInputToList(Console.ReadLine());
    try
    {
        evaluateStatements(list);
    }
    catch (NotImplementedException e) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
    }
    
    
}


ListElement parseInputToList(string input) 
{
    ListElement result = new ListElement();

    if (input.Equals("exit")) { Environment.Exit(1); }

    Stack<int> openBrackets = new Stack<int>();

    string currentSymbol = "";

    for (; i < input.Length; i++)
    {
        switch (input[i]) 
        {
            case '(':
                i++;
                result.list.Add(new ListElement(parseInputToList(input)));
                break;
            case ')': 
                if (currentSymbol != "")
                {
                    result.list.Add(new ListElement(currentSymbol));
                    currentSymbol = "";
                }
                return result;
            case ' ':
                if (currentSymbol == "") break;
                result.list.Add(new ListElement(currentSymbol)); currentSymbol = "";
                break;
            default:
                currentSymbol += input[i];
                break;
        }
    }
    return result;
}
