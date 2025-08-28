using System;
using System.Collections;
public class MyList<T> : IList<T>
{
    public T[]? array;
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            return array[index];
        }
        set
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            array[index] = (T)value;
        }
    }

    private int count = 0;
    public int Count => count;

    public bool IsReadOnly => false;

    public MyList()
    {
        array = new T[4];
    }

    public void Add(T item)
    {
        if (Count >= array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }

        array[Count] = item;
        count++;
    }

    public void Clear()
    {
        for (int i = 0; i < Count; i++)
        {
            array[i] = default(T);
        }
        count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (array[i].Equals(item))
                return true;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException("array");
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException("arrayIndex");
        if (arrayIndex >= Count) throw new ArgumentOutOfRangeException("arrayIndex");

        for (int i = arrayIndex; i < array.Length; i++)
        {
            this.array[i] = array[i];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return array[i];
        }
    }
    public int IndexOf(T item)
    {
        int index;
        for (index = 0; index < Count; index++)
        {
            if (array[index].Equals(item))
            {
                break;
            }
        }
        return index;
    }
    public void Insert(int index, T item)
    {
        if (index > Count || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        if (Count == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }
        //만약 현재 카운트가 3이고 인덱스는 1

        for (int i = Count; i > index; i--)
        {
            array[i] = array[i - 1];
        }
        // 검 활 방패 물약 ㅁ ㅁ
        // 검 방패 방패 물약 

        array[index] = item;
        count++;
    }

    public bool Remove(T item)
    {
        if (item == null) throw new ArgumentNullException("item");
        if (!Contains(item)) return false;

        RemoveAt(IndexOf(item));
        return true;
    }

    public void RemoveAt(int index)
    {
        if (index > Count || index < 0) return;
        for (int i = index; i < Count; ++i)
        {
            if (i == index)
            {
                array[i] = default(T);
                count--;
            }
            array[i] = array[i + 1];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
