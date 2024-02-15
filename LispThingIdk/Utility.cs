using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (Functions.getAllFunctionIdentifiers().Contains(input)) return DataType.OPERATOR;
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
        
    }

}
