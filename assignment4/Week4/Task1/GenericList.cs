namespace Week4;

public class GenericList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public GenericList()
    {
        tail = head = null;
    }

    public Node<T> Head
    {
        get => Head;
    }

    public void Add(T t)
    {
        Node<T> n = new Node<T>(t);
        if (tail == null)
        {
            head = tail = n;
        }
        else {
                tail.Next = n;
                tail = n;
        }
    }

    public void ForEach(Action<T> action)
    {
        for (Node<T> node = head; node != null; node = node.Next)
        {
            action(node.Data);
        }
    }
}
