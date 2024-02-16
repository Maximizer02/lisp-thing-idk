using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LispThingIdk
{
    internal class Utility
    {
        public static void printListElement(ListElement listElements, string offset)
        {
            if (!listElements.list.Any()) return;
            foreach (ListElement l in listElements.list)
            {
                Console.ForegroundColor = l.type==DataType.LIST?ConsoleColor.Blue:ConsoleColor.Red;
                Console.WriteLine(offset+ "Type:" + l.type+"; Eval: "+ !l.noEval);
                if (!l.list.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(offset + "'" + l.content + "' Depth: " + (offset.Length-1) );
                }
                else { printListElement(l, offset + " "); }
            }
            Console.ResetColor();
        }


        public static DataType determineDatatype(string input) {
            if (input.Equals("")) return DataType.UNDEF;
            List<string> allFunctionIdentifiers = Functions.getAllFunctionIdentifiers();


            if (allFunctionIdentifiers.Contains(input)) return DataType.OPERATOR;
            if (canConvertBool(input))  return DataType.BOOL; 
            if (canConvertDouble(input))  return DataType.DOUBLE; ; 
            if (canConvertInt(input))  return DataType.INT;  
            return DataType.STRING;
        }


        public static bool canConvertDouble(string val) 
        {
            if(!(val.Contains('.')||val.Contains(','))) return false;
            try
            {
                double kekw = double.Parse(val);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public static bool canConvertInt(string val) 
        {
            try
            {
                int kekw = int.Parse(val);
                return true;
            }
            catch 
            {
                return false;
            }
        }
        
        public static bool canConvertBool(string val) 
        {
            try
            {
                bool kekw = bool.Parse(val);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static string getListAsString(ListElement list) 
        {
            string res = "";
            list.list.ForEach(x => res += x.content==""?"("+getListAsString(x)+")|": x.content + "|") ;
            //res = res.Remove(res.Length - 1);
            return res ;
        }

        public static bool containsElement(ListElement list , string element) 
        {
            foreach (var item in list.list) 
            {
                if (item.content==element)
                {
                    return true;
                }
                if (containsElement(item,element)) return true;

            }
            return false;
        }

        public static List<ListElement> replaceElement(List<ListElement> list, string target, string newElement) 
        {
            ListElement result = new ListElement();
            result.list.AddRange(list);
            foreach (var item in result.list) 
            {
                if (item.content == target) item.content = newElement;
                if (item.list.Count > 0) replaceElement(item.list, target, newElement);
            }
            return result.list;
        }

        public static List<ListElement> setDataTypeWhere(List<ListElement> list, string target, DataType newType) 
        {
            ListElement result = new ListElement();
            result.list.AddRange(list);
            foreach (var item in result.list) 
            {
                if (item.content == target) item.type = newType;
                if (item.list.Any()) setDataTypeWhere(item.list, target, newType); 
            }
            return result.list;
        }
        
    }

}
