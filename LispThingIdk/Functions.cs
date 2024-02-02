namespace LispThingIdk
{
    internal class Functions
    {

        // TODO: Recursion

        // TOTO: working variable declaration

        // TODO: everything to do with doubles lol

        private static Dictionary<string, string> constants = new Dictionary<string, string>();
        private static Dictionary<string, int> integerVariables = new Dictionary<string, int>();
        public static Dictionary<string, string> monadicCustomFunctions = new Dictionary<string, string>();
        public static  Dictionary<string, string> diadicCustomFunctions = new Dictionary<string, string>();

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
            {"get", a => constants.ContainsKey(a)?constants[a]:"-1" },
            { "?", a=> {Console.WriteLine(a); return a; } }
        };
        public static Dictionary<string, Func<string, int, int>> diadicFuncsStringIntInt = new Dictionary<string, Func<string, int, int>>
        {
            {"var", (a,b) =>    {integerVariables.Add(a,b); return b; } },
            {"set", (a,b) =>    integerVariables.ContainsKey(a)?integerVariables[a]=b:-1  }
        };
        public static Dictionary<string, Func<string, int>> monadicFuncsStringInt = new Dictionary<string, Func<string, int>>
        {
            {"get", a=>integerVariables.ContainsKey(a)?integerVariables[a]:-1 }
        };
    }
}
