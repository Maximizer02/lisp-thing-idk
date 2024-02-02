namespace LispThingIdk
{
    public class ListElement
    {
        public List<ListElement>? list { get; }
        public string? content { get; set; }
        public ListElement(string _content) { content = _content; }
        public ListElement(ListElement _list) { list = _list.list; }
        public ListElement() {  list = new List<ListElement>(); }
    }
}
