using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispThingIdk
{
    public class ListElement
    {
        public List<ListElement> list { get; }
        public string content { get; }
        public ListElement(string _content) { content = _content; }
        public ListElement(List<ListElement> _list) { list = _list; }
    }
}
