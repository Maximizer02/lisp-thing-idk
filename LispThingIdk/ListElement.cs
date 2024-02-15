namespace LispThingIdk
{
    public class ListElement
    {
        public bool noEval = false;
        public List<ListElement> list { get; }
        public string content { get; set; }
        public DataType type { get;  }
        public ListElement(string _content) 
        { 
           content = _content;
           list = new List<ListElement>();
           type = Utility.determineDatatype(_content); 
        }
        public ListElement(ListElement _list) { list = _list.list; content = ""; type = DataType.LIST; }
        public ListElement(ListElement _list,bool evalType) { list = _list.list;noEval = evalType; content = ""; type = DataType.LIST; }
        public ListElement() {  list = new List<ListElement>(); content = ""; type = DataType.UNDEF; }
    }
}
