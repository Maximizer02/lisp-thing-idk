using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispThingIdk
{
    public class ListElement :IListElement
    {
        string content;
        public ListElement(string _content) { content = _content; }
    }
}
