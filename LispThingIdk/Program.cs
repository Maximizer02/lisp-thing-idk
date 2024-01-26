Dictionary<string, Func<int, int, int>> diadicIntFunctionsOutInt = new Dictionary<string, Func<int, int, int>>
{
    { "+", (a, b) => a + b },
    { "-", (a, b) => a - b },
    { "/", (a, b) => a / b },
    { "*", (a, b) => a * b },
    { "%", (a, b) => a % b },
    { "^", (a, b) => {int r = 1;for(int i = 0;i<b;i++){r*=a;}return r;} }
};
Dictionary<string, Func<int, int, bool>> diadicIntFunctionsOutBool = new Dictionary<string, Func<int, int, bool>>
{
    { "<", (a, b) => a < b },
    { ">", (a, b) => a > b },
    { "=", (a, b) => a == b },
    { "!=", (a, b) => a != b }
};

Dictionary<string, Func<int, int>> monadicIntFunctionsOutInt  = new Dictionary<string, Func<int, int>>
{
    { "?", a=> {Console.WriteLine(a); return a; } },
    { "^", a=> a*a } 
};

Dictionary<string, Func<bool, bool>> monadicBoolFunctionsOutBool = new Dictionary<string, Func<bool, bool>>
{
    { "?", a=> {Console.WriteLine(a); return a; } },
    { "!", a=> !a }
};

// TODO: diadic bool out bool (aka. everything to do with boolean expressions)
Dictionary<string, Func<bool, bool, bool>> diadicBoolFunctionsOutBool = new Dictionary<string, Func<bool, bool, bool>>
{
    {"&", (a,b) =>  a && b },
    {"|", (a,b) =>  a || b },
    {"§", (a,b) =>  a ^ b }
};

// TOTO: diadic string int out bool for variable declaration
// TODO: everything to do with doubles lol

// TODO: make this not while true
while (true)
{
    parseInput(Console.ReadLine());
}



void parseInput(string input)
{
    if (input.Equals("exit")) { Environment.Exit(1); }

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

string parseStatement(string statement)
{
    string[] operands = statement.Split(' ');
    // TODO: Unfuck this
    try {  return parseStatementIntIntInt(operands[0], operands[1], operands[2]) + "";}catch(Exception) {  }
    try {  return parseStatementIntIntBool(operands[0], operands[1], operands[2]) +"";}catch(Exception) { }
    try {  return parseStatementBoolBoolBool(operands[0], operands[1], operands[2]) +"";}catch(Exception) { }
    try {  return parseStatementIntInt(operands[0], operands[1]) +"";}catch(Exception) { }
    try {  return parseStatementBoolBool(operands[0], operands[1]) +"";}catch(Exception) { }
   
    return "";
}

//Diadic Functions
int parseStatementIntIntInt(string op, string _alpha, string _omega)
{
    int alpha = int.Parse(_alpha);
    int omega = int.Parse(_omega);
  if (diadicIntFunctionsOutInt.ContainsKey(op))
    {
        return diadicIntFunctionsOutInt[op](alpha, omega);
    }
    throw new Exception();
}

bool parseStatementIntIntBool(string op, string _alpha, string _omega) 
{
    int alpha = int.Parse(_alpha);
    int omega = int.Parse(_omega);
    if (diadicIntFunctionsOutBool.ContainsKey(op))
    {
        return diadicIntFunctionsOutBool[op](alpha, omega);
    }
    throw new Exception();
}

bool parseStatementBoolBoolBool(string op, string _alpha, string _omega) 
{
    bool alpha = bool.Parse(_alpha);
    bool omega = bool.Parse(_omega);    
    if (diadicBoolFunctionsOutBool.ContainsKey(op))
    {
        return diadicBoolFunctionsOutBool[op](alpha, omega);
    }
    throw new Exception();
}



//Monadic Functions
int parseStatementIntInt(string op, string _omega) 
{
    int omega = int.Parse(_omega) ;
    if (monadicIntFunctionsOutInt.ContainsKey(op))
    {
        return monadicIntFunctionsOutInt[op](omega);
    }
    throw new Exception();
}

bool parseStatementBoolBool(string op, string _omega) 
{
    bool omega = bool.Parse(_omega);
    if (monadicBoolFunctionsOutBool.ContainsKey(op))
    {
        return monadicBoolFunctionsOutBool [op](omega);
    }
    throw new Exception();
}
