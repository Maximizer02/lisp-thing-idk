using System;
using System.Collections.Generic;
using System.Diagnostics;
using static LispThingIdk.Functions;
namespace LispThingIdk
{
    internal class Evaluater
    {

        public static string evaluateStatements(ListElement code)
        {
            if (!code.list.Any() && code.content == "") return "";
            if (!code.list.Any() && code.content != "") return code.content;
            //if(code.list == null) throw new NotImplementedException("Fuck you");

            foreach (ListElement symbol in code.list)
            {
                if (symbol.content == "" && symbol.list.Any())
                {
                    symbol.content = evaluateStatements(symbol);
                }
            }
            if (code.list.Count == 1)
            {
                return code.list[0].content;
            }
            return evaluateStatement(code);
        }



        private static string evaluateStatement(ListElement statement)
        {
            //if (statement.list == null) { throw new NotImplementedException("No"); }

            string[] operands = new string[statement.list.Count];
            for (int i = 0; i < statement.list.Count; i++) 
            {
                operands[i] = statement.list[i].content;
            }
           
            // TODO: Unfuck this
            try { return parseStatementIntIntInt(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }
            try { return parseStatementIntIntBool(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }
            try { return parseStatementBoolBoolBool(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }
            try { return parseStatementBoolStringString(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }
            try { return parseStatementStringIntInt(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }
            try { return parseStatementStringStringString(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }
            try { return parseDiadicCustomFunction(operands[0], operands[1], operands[2]) + ""; } catch (Exception) { }

            try { return parseStatementIntInt(operands[0], operands[1]) + ""; } catch (Exception) { }
            try { return parseStatementBoolBool(operands[0], operands[1]) + ""; } catch (Exception) { }
            try { return parseStatementStringInt(operands[0], operands[1]) + ""; } catch (Exception) { }
            try { return parseStatementStringString(operands[0], operands[1]) + ""; } catch (Exception) { }
            try { return parseMonadicCustomFunction(operands[0], operands[1]) + ""; } catch (Exception) { }

            throw new NotImplementedException("This function does not exist");
        }

        //Diadic Functions
        private static int parseStatementIntIntInt(string op, string _alpha, string _omega)
        {
            int alpha = int.Parse(_alpha);
            int omega = int.Parse(_omega);
            if (diadicFuncsIntIntInt.ContainsKey(op))
            {
                return diadicFuncsIntIntInt[op](alpha, omega);
            }
            throw new Exception();
        }

        private static bool parseStatementIntIntBool(string op, string _alpha, string _omega)
        {
            int alpha = int.Parse(_alpha);
            int omega = int.Parse(_omega);
            if (diadicFuncsIntIntBool.ContainsKey(op))
            {
                return diadicFuncsIntIntBool[op](alpha, omega);
            }
            throw new Exception();
        }

        private static bool parseStatementBoolBoolBool(string op, string _alpha, string _omega)
        {
            bool alpha = bool.Parse(_alpha);
            bool omega = bool.Parse(_omega);
            if (diadicFuncsBoolBoolBool.ContainsKey(op))
            {
                return diadicFuncsBoolBoolBool[op](alpha, omega);
            }
            throw new Exception();
        }

        private static string parseStatementBoolStringString(string op, string _alpha, string _omega)
        {
            bool alpha = bool.Parse(_alpha);
            if (diadicFuncsBoolStringString.ContainsKey(op))
            {
                return diadicFuncsBoolStringString[op](alpha, _omega);
            }
            throw new Exception();
        }

        private static int parseStatementStringIntInt(string op, string _alpha, string _omega)
        {
            int omega = int.Parse(_omega);
            if (diadicFuncsStringIntInt.ContainsKey(op))
            {
                return diadicFuncsStringIntInt[op](_alpha, omega);
            }
            throw new Exception();
        }
        private static string parseStatementStringStringString(string op, string _alpha, string _omega)
        {
            if (diadicFuncsStringStringString.ContainsKey(op))
            {
                return diadicFuncsStringStringString[op](_alpha, _omega);
            }
            throw new Exception();
        }


        //Monadic Functions
        private static int parseStatementIntInt(string op, string _alpha)
        {
            int omega = int.Parse(_alpha);
            if (monadicFuncsIntInt.ContainsKey(op))
            {
                return monadicFuncsIntInt[op](omega);
            }
            throw new Exception();
        }

        private static bool parseStatementBoolBool(string op, string _alpha)
        {
            bool omega = bool.Parse(_alpha);
            if (monadicFuncsBoolBool.ContainsKey(op))
            {
                return monadicFuncsBoolBool[op](omega);
            }
            throw new Exception();
        }

        private static int parseStatementStringInt(string op, string _alpha)
        {
            if (monadicFuncsStringInt.ContainsKey(op))
            {
                return monadicFuncsStringInt[op](_alpha);
            }
            throw new Exception();
        }

        private static string parseStatementStringString(string op, string _alpha)
        {
            if (monadicFuncsStringString.ContainsKey(op))
            {
                return monadicFuncsStringString[op](_alpha);
            }
            throw new Exception();
        }


        //Parse custom functions
        private static string parseMonadicCustomFunction(string op, string _alpha)
        {
            if (monadicCustomFunctions.ContainsKey(op))
            {
                return monadicCustomFunctions[op].Replace("a", _alpha);
            }
            throw new Exception();
        }
        private static string parseDiadicCustomFunction(string op, string _alpha, string _omega)
        {
            if (diadicCustomFunctions.ContainsKey(op))
            {
                return diadicCustomFunctions[op].Replace("a", _alpha).Replace("o", _omega);
            }
            throw new Exception();
        }
    }
}
