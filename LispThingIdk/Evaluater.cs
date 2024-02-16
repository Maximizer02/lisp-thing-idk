using System;
using System.Collections.Generic;
using System.Diagnostics;
using static LispThingIdk.Functions;
namespace LispThingIdk
{
    internal class Evaluater
    {

        public static ListElement evaluateStatements(ListElement code)
        {
            if (!code.list.Any() && code.content == "") return new ListElement();
            if (!code.list.Any() && code.content != "") return code;
            if (code.noEval) return code;
            code.list.RemoveAll(x => x.type == DataType.UNDEF || (x.content == "" && !x.list.Any()));
            

            for(int element = 0;element < code.list.Count;element++)
            {
                if (code.list[element].type==DataType.LIST)
                {
                    code.list[element] = evaluateStatements(code.list[element]);
                }
            }
            if (code.list.Count == 1)
            {
                return code.list[0];
            }
            return evaluateStatement(code);
        }



        private static ListElement evaluateStatement(ListElement statement)
        {
            /*
            Utility.printListElement(statement, " ");
            statement.list.ForEach(x => Console.Write(x.content==""?Utility.getListAsString(x):x.content+"; "));
            Console.WriteLine(" "+statement.noEval);*/
           
            ListElement _operator,_op1,_op2;
            if (statement.noEval) 
            {
                statement.type= DataType.DataList;
                return statement; 
            }

            try 
            {
             _operator = statement.list.First(x=>x.type==DataType.OPERATOR);
             _op1 = statement.list.First(x => x.type != DataType.OPERATOR);
             _op2 = statement.list.Last(x => x.type != DataType.OPERATOR);
            }
            catch { Console.WriteLine("Fuck"); return statement; }
            string op0 = _operator.content;
            string op1=_op1.content;
            string op2=_op2.content;


            // TODO: Unfuck this

            
            try { return parseStatementListList(op0, _op1); } catch (Exception) { }
            
            try { return parseStatementListListList(op0, _op1,_op2); } catch (Exception) { }

            try { return new ListElement(parseStatementStringListList(op0, op1, _op2) + ""); } catch (Exception) { }


            try { return parseDiadicCustomFunction(op0, op1, op2); } catch (Exception) { }
            try { return parseMonadicCustomFunction(op0, op1) ; } catch (Exception e) { }

            try { return new ListElement(parseStatementIntIntInt(op0, op1, op2) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementIntIntBool(op0, op1, op2) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementBoolBoolBool(op0, op1, op2) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementBoolStringString(op0, op1, op2) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementStringIntInt(op0, op1, op2) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementStringStringString(op0, op1, op2) + ""); } catch (Exception) { }
           

            try { return new ListElement(parseStatementIntInt(op0, op1) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementBoolBool(op0, op1) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementStringInt(op0, op1) + ""); } catch (Exception) { }
            try { return new ListElement(parseStatementStringString(op0, op1) + ""); } catch (Exception e) {  }
            
           

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

        private static ListElement parseStatementListListList(string op, ListElement _alpha, ListElement _omega)
        {
            if (_alpha.content != ""|| _omega.content != "") throw new Exception();
            if (diadicFuncsListListList.ContainsKey(op))
            {
                return diadicFuncsListListList[op](_alpha,_omega);
            }
            throw new Exception();
        }
        
        
        private static ListElement parseStatementStringListList(string op, string _alpha, ListElement _omega)
        {
            if (_omega.content != "") throw new Exception();
            if (diadicFuncsStringListList.ContainsKey(op))
            {
                return diadicFuncsStringListList[op](_alpha,_omega);
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

        private static ListElement parseStatementListList(string op, ListElement _alpha)
        {
            if(_alpha.content!="") throw new Exception();
            if (monadicFuncsListList.ContainsKey(op))
            {
                return monadicFuncsListList[op](_alpha);
            }
            throw new Exception();
        }

     


        //Parse custom functions
        private static ListElement parseMonadicCustomFunction(string op, string _alpha)
        {
  
            //Console.WriteLine(monadicCustomFunctions.ContainsKey(op));

            if (monadicCustomFunctions.ContainsKey(op))
            {
                /*
                Console.WriteLine("#######");
                Utility.printListElement(monadicCustomFunctions[op], " ");
                Console.WriteLine ("#######");*/

                ListElement functionBody = monadicCustomFunctions[op].Clone();
                /*
                Utility.printListElement(functionBody, " ");
                Console.WriteLine("#######");*/
                functionBody.noEval = false;

                functionBody.list = Utility.replaceElement(functionBody.list, "a", _alpha);
                return evaluateStatements(functionBody);

            }
            throw new Exception();
        }
        private static ListElement parseDiadicCustomFunction(string op, string _alpha, string _omega)
        {
            if (diadicCustomFunctions.ContainsKey(op))
            {
                

                ListElement functionBody = diadicCustomFunctions[op].Clone();
                
                functionBody.noEval = false;

                functionBody.list = Utility.replaceElement(functionBody.list, "a", _alpha);
                functionBody.list = Utility.replaceElement(functionBody.list, "b", _omega);
                return evaluateStatements(functionBody);

            }
            throw new Exception();
        }
    }
}
