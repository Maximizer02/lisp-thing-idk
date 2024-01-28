Dictionary<string, string> constants = new Dictionary<string, string>();
Dictionary<string, int> integerVariables = new Dictionary<string, int>();

Dictionary<string, Func<int, int, int>> diadicFuncsIntIntInt = new Dictionary<string, Func<int, int, int>>
{
    { "+", (a, b) => a + b },
    { "-", (a, b) => a - b },
    { "/", (a, b) => a / b },
    { "*", (a, b) => a * b },
    { "%", (a, b) => a % b },
    { "^", (a, b) => {int r = 1;for(int i = 0;i<b;i++){r*=a;}return r;} }
};
Dictionary<string, Func<int, int, bool>> diadicFuncsIntIntBool = new Dictionary<string, Func<int, int, bool>>
{
    { "<", (a, b) => a < b },
    { ">", (a, b) => a > b },
    { "=", (a, b) => a == b },
    { "!=", (a, b) => a != b }
};

Dictionary<string, Func<int, int>> monadicFuncsIntInt  = new Dictionary<string, Func<int, int>>
{
    { "?", a=> {Console.WriteLine(a); return a; } },
    { "^", a=> a*a } 
};

Dictionary<string, Func<bool, bool>> monadicFuncsBoolBool = new Dictionary<string, Func<bool, bool>>
{
    { "?", a=> {Console.WriteLine(a); return a; } },
    { "!", a=> !a }
};

Dictionary<string, Func<bool, bool, bool>> diadicFuncsBoolBoolBool = new Dictionary<string, Func<bool, bool, bool>>
{
    {"&", (a,b) =>  a && b },
    {"|", (a,b) =>  a || b },
    {"§", (a,b) =>  a ^ b }
};

Dictionary<string, Func<bool, string, string>> diadicFuncsBoolStringString = new Dictionary<string, Func<bool, string, string>>
{
    {"if", (a,b) => a?b:"" }
};

Dictionary<string, Func<string, string, string>> diadicFuncsStringStringString = new Dictionary<string, Func<string, string, string>>
{
    {"def", (a,b) =>    {constants.Add(a,b); return b; } },
    {"+", (a,b) =>    {return a+b; } },
};
Dictionary<string, Func<string, string>> monadicFuncsStringString = new Dictionary<string, Func<string, string>>
{
    {"get", a => constants.ContainsKey(a)?constants[a]:"-1" },
    { "?", a=> {Console.WriteLine(a); return a; } }
};
Dictionary<string, Func<string, int, int>> diadicFuncsStringIntInt = new Dictionary<string, Func<string, int, int>>
{
    {"var", (a,b) =>    {integerVariables.Add(a,b); return b; } },
    {"set", (a,b) =>    integerVariables.ContainsKey(a)?integerVariables[a]=b:-1  }


};
Dictionary<string, Func<string, int>> monadicFuncsStringInt = new Dictionary<string, Func<string, int>>
{
    {"get", a=>integerVariables.ContainsKey(a)?integerVariables[a]:-1 }
};





// TODO: Control flow

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
    try {  return parseStatementBoolStringString(operands[0], operands[1], operands[2]) +"";}catch(Exception) { }
    try {  return parseStatementStringIntInt(operands[0], operands[1], operands[2]) +"";}catch(Exception) { }
    try {  return parseStatementStringStringString(operands[0], operands[1], operands[2]) +"";}catch(Exception) { }
    try {  return parseStatementIntInt(operands[0], operands[1]) +"";}catch(Exception) { }
    try {  return parseStatementBoolBool(operands[0], operands[1]) +"";}catch(Exception) { }
    try {  return parseStatementStringInt(operands[0], operands[1]) +"";}catch(Exception) { }
    try {  return parseStatementStringString(operands[0], operands[1]) +"";}catch(Exception) { }
   
    return "";
}

//Diadic Functions
int parseStatementIntIntInt(string op, string _alpha, string _omega)
{
    int alpha = int.Parse(_alpha);
    int omega = int.Parse(_omega);
  if (diadicFuncsIntIntInt.ContainsKey(op))
    {
        return diadicFuncsIntIntInt[op](alpha, omega);
    }
    throw new Exception();
}

bool parseStatementIntIntBool(string op, string _alpha, string _omega) 
{
    int alpha = int.Parse(_alpha);
    int omega = int.Parse(_omega);
    if (diadicFuncsIntIntBool.ContainsKey(op))
    {
        return diadicFuncsIntIntBool[op](alpha, omega);
    }
    throw new Exception();
}

bool parseStatementBoolBoolBool(string op, string _alpha, string _omega) 
{
    bool alpha = bool.Parse(_alpha);
    bool omega = bool.Parse(_omega);    
    if (diadicFuncsBoolBoolBool.ContainsKey(op))
    {
        return diadicFuncsBoolBoolBool[op](alpha, omega);
    }
    throw new Exception();
}

string parseStatementBoolStringString(string op, string _alpha, string _omega)
{
    bool alpha = bool.Parse(_alpha);
    if (diadicFuncsBoolStringString.ContainsKey(op))
    {
        return diadicFuncsBoolStringString[op](alpha,_omega);
    }
    throw new Exception();
}

int parseStatementStringIntInt(string op, string _alpha, string _omega)
{
    int omega = int.Parse(_omega);
    if (diadicFuncsStringIntInt.ContainsKey(op))
    {
        return diadicFuncsStringIntInt[op](_alpha, omega);
    }
    throw new Exception();
}
string parseStatementStringStringString(string op, string _alpha, string _omega)
{
    if (diadicFuncsStringStringString.ContainsKey(op))
    {
        return diadicFuncsStringStringString[op](_alpha,_omega);
    }
    throw new Exception();
}


//Monadic Functions
int parseStatementIntInt(string op, string _omega) 
{
    int omega = int.Parse(_omega) ;
    if (monadicFuncsIntInt.ContainsKey(op))
    {
        return monadicFuncsIntInt[op](omega);
    }
    throw new Exception();
}

bool parseStatementBoolBool(string op, string _omega) 
{
    bool omega = bool.Parse(_omega);
    if (monadicFuncsBoolBool.ContainsKey(op))
    {
        return monadicFuncsBoolBool [op](omega);
    }
    throw new Exception();
}

int parseStatementStringInt(string op, string _omega) 
{
    if (monadicFuncsStringInt.ContainsKey(op))
    {
        return monadicFuncsStringInt[op](_omega);
    }
    throw new Exception();
}

string parseStatementStringString(string op, string _omega) 
{
    if (monadicFuncsStringString.ContainsKey(op))
    {
        return monadicFuncsStringString[op](_omega);
    }
    throw new Exception();
}
