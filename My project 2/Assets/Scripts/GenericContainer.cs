public class GenericContainer<T>
{
    private T[] items;
    private int currentIndex = 0;

    public GenericContainer(int capacity)
    {
        items = new T[capacity];
    }

    public void Add(T item)
    {
        if (currentIndex < items.Length)
        {
            items[currentIndex++] = item;
        }
    }

    public T[] GetItems()
    {
        return items;
    }
}