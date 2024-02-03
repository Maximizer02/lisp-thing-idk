namespace LispThingIdk
{
    public class ListElement
    {
        public List<ListElement> list { get; }
        public string content { get; set; }
        public ListElement(string _content) { content = _content; list = new List<ListElement>(); }
        public ListElement(ListElement _list) { list = _list.list; content = ""; }
        public ListElement() {  list = new List<ListElement>(); content = ""; }
    }
}
