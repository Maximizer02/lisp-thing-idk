using LispThingIdk;
using static LispThingIdk.Evaluater;

namespace LispThingIdk 
{
    class Program 
    {
        static ListElement list = new ListElement();
        static int i;
        static void Main(string[] args) 
        {
            // TODO: make this not while true
            while (true)
            {
                i = 0;
                string input = Console.ReadLine() ?? "";
                if (input == null || input == "") continue;
                list = parseInputToList(input);
                
                Utility.printListElement(list," ");
                
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

        }


        static ListElement parseInputToList(string input)
        {
            if (input.Equals("exit")) { Environment.Exit(0); }

            ListElement result = new ListElement();
            string currentSymbol = "";

            for (; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '[':
                        if (currentSymbol != "")
                        {
                            result.list.Add(new ListElement(currentSymbol)); currentSymbol = "";
                        }
                        i++;
                        result.list.Add(new ListElement(parseInputToList(input),true));
                        break;
                    case ']':
                        if (currentSymbol != "")
                        {
                            result.list.Add(new ListElement(currentSymbol));
                        }
                        return result;
                    case '(':
                        if (currentSymbol != "") { 
                        result.list.Add(new ListElement(currentSymbol)); currentSymbol = "";}
                        i++;
                        result.list.Add(new ListElement(parseInputToList(input)));
                        break;
                    case ')':
                        if (currentSymbol != "")
                        {
                            result.list.Add(new ListElement(currentSymbol));
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

    }
}











