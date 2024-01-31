using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispThingIdk
{
    public class SubList :IListElement
    {
        List<IListElement> list;
        public SubList(List<IListElement> _list) { list = _list; }
    }
}
