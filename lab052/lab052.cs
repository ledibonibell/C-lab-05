using System;

public class MyList<T>
{
    private T[] items;
    private int count;

    public MyList()
    {
        items = new T[0];
        count = 0;
    }

    public MyList(params T[] initialValues)
    {
        items = new T[initialValues.Length];
        Array.Copy(initialValues, items, initialValues.Length);
        count = initialValues.Length;
    }

    public void Add(T item)
    {
        if (count == items.Length)
        {
            int newCapacity = count == 0 ? 4 : count * 2;
            T[] newItems = new T[newCapacity];
            Array.Copy(items, newItems, count);
            items = newItems;
        }

        items[count] = item;
        count++;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            return items[index];
        }
    }

    public int Count
    {
        get { return count; }
    }
}

class lab052
{
    static void Main()
    {
        MyList<int> myList = new MyList<int>(1, 2, 3, 4, 5);

        myList.Add(678);

        Console.WriteLine($"Our elements i - 1, cheeeeck:\n");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine($"Element {i}: {myList[i]}");
        }

        Console.WriteLine($"\nTotal number of elements: {myList.Count}");
    }
}
