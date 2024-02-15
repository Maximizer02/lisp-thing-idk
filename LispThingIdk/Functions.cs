namespace LispThingIdk
{
    internal class Functions
    {

        // TODO: Recursion

        // TOTO: working variable declaration

        // TODO: everything to do with doubles lol

        //TODO damit könnte ich den evaluator doch mies vereinfachen, oder?
        List<Dictionary<string, ListElement>> monadicFunctions = new List<Dictionary<string, ListElement>>();
        List<Dictionary<string, ListElement>> diadicFunctions = new List<Dictionary<string, ListElement>>();

        private static Dictionary<string, string> constants = new Dictionary<string, string>();
        private static Dictionary<string, int> integerVariables = new Dictionary<string, int>();
        public static Dictionary<string, string> monadicCustomFunctions = new Dictionary<string, string>();
        public static Dictionary<string, string> diadicCustomFunctions = new Dictionary<string, string>();

        public static Dictionary<string, Func<int, int, int>> diadicFuncsIntIntInt = new Dictionary<string, Func<int, int, int>>
        {
            { "+", (a, b) => a + b },
            { "-", (a, b) => a - b },
            { "/", (a, b) => a / b },
            { "*", (a, b) => a * b },
            { "%", (a, b) => a % b },
            { "^", (a, b) => {int r = 1;for(int i = 0;i<b;i++){r*=a;}return r;} }
        };
        public static Dictionary<string, Func<int, int, bool>> diadicFuncsIntIntBool = new Dictionary<string, Func<int, int, bool>>
        {
            { "<", (a, b) => a < b },
            { ">", (a, b) => a > b },
            { "=", (a, b) => a == b },
            { "!=", (a, b) => a != b }
        };

        public static Dictionary<string, Func<int, int>> monadicFuncsIntInt = new Dictionary<string, Func<int, int>>
        {
            { "?", a=> {Console.WriteLine(a); return a; } },
            { "^", a=> a*a }
        };

        public static Dictionary<string, Func<bool, bool>> monadicFuncsBoolBool = new Dictionary<string, Func<bool, bool>>
        {
            { "?", a=> {Console.WriteLine(a); return a; } },
            { "!", a=> !a }
        };

        public static Dictionary<string, Func<bool, bool, bool>> diadicFuncsBoolBoolBool = new Dictionary<string, Func<bool, bool, bool>>
        {
            {"&", (a,b) =>  a && b },
            {"|", (a,b) =>  a || b },
            {"§", (a,b) =>  a ^ b }
        };

        public static Dictionary<string, Func<bool, string, string>> diadicFuncsBoolStringString = new Dictionary<string, Func<bool, string, string>>
        {
            {"if", (a,b) => a?b:"" }
        };

        public static Dictionary<string, Func<string, string, string>> diadicFuncsStringStringString = new Dictionary<string, Func<string, string, string>>
        {
            {"def", (a,b) =>    {constants.Add(a,b); return b; } },
            {"fn", (a,b)  =>  {if(b.Contains("a")){
                               if(b.Contains("b")){diadicCustomFunctions.Add(a,b); }
                               else{monadicCustomFunctions.Add(a,b); } }
                               return "";}},
            {"+", (a,b) =>    {return a+b; } },
        };
        public static Dictionary<string, Func<string, string>> monadicFuncsStringString = new Dictionary<string, Func<string, string>>
        {
            {"get", a => constants[a] },
            { "?", a=> {Console.WriteLine(a); return a; } }
        };
        public static Dictionary<string, Func<string, int, int>> diadicFuncsStringIntInt = new Dictionary<string, Func<string, int, int>>
        {
            {"var", (a,b) =>    {integerVariables.Add(a,b); return b; } },
            {"set", (a,b) =>    integerVariables.ContainsKey(a)?integerVariables[a]=b:-1  }
        };
        public static Dictionary<string, Func<string, int>> monadicFuncsStringInt = new Dictionary<string, Func<string, int>>
        {
            {"get", a=>integerVariables[a] }
        };
        public static Dictionary<string, Func<ListElement, ListElement>> monadicFuncsListList = new Dictionary<string, Func<ListElement, ListElement>> 
        {
            {"?", a=>{Console.WriteLine(a.list.ToString()); return a; }}
        };

        public static List<string> getAllFunctionIdentifiers()  
        {
        List<string> res =
        [
            .. diadicFuncsIntIntInt.Keys.ToList(),
            .. diadicFuncsIntIntBool.Keys.ToList(),
            .. monadicFuncsIntInt.Keys.ToList(),
            .. monadicFuncsBoolBool.Keys.ToList(),
            .. diadicFuncsBoolBoolBool.Keys.ToList(),
            .. diadicFuncsBoolStringString.Keys.ToList(),
            .. diadicFuncsStringStringString.Keys.ToList(),
            .. monadicFuncsStringString.Keys.ToList(),
            .. diadicFuncsStringIntInt.Keys.ToList(),
            .. monadicFuncsStringInt.Keys.ToList(),
        ];

        return res;
        }
    }
}
