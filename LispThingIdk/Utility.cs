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
            if (listElements.list == null) return;
            foreach (ListElement l in listElements.list)
            {
                if (l.list == null)
                {
                    Console.WriteLine(offset + "'" + l.content + "' Depth: " + offset.Length + " List:");
                }
                else { printListElement(l, offset + " "); }
            }
        }
    }
}
