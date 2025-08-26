// 문자열 리스트 테스트
using System.Collections;

Console.WriteLine("=== 문자열 리스트 테스트 ===");
var stringList = new MyList<string>();

//stringList.Add("검");
//stringList.Add("방패");
//stringList.Add("물약");

Console.WriteLine($"아이템 개수: {stringList.Count}");  // 3
for (int i = 0; i < stringList.Count; i++)
{
    Console.WriteLine($"아이템 {i}: {stringList[i]}");
}

stringList.Insert(1, "활");
Console.WriteLine("\n활 삽입 후:");
foreach (var item in stringList)  // foreach 테스트
{
    Console.WriteLine(item);
}
// 검, 활, 방패, 물약

// GameItem 리스트 테스트
Console.WriteLine("\n=== 게임 아이템 리스트 테스트 ===");
var inventory = new MyList<GameItem>();

var sword = new GameItem("강철검", 10);
var armor = new GameItem("미스릴 갑옷", 20);
var potion = new GameItem("힐링 포션", 5);

inventory.Add(sword);
inventory.Add(armor);
inventory.Add(potion);

Console.WriteLine("현재 인벤토리:");
foreach (var item in inventory)
{
    Console.WriteLine(item);
}

Console.WriteLine($"\n강철검 보유 여부: {inventory.Contains(sword)}");  // True

inventory.Clear();
Console.WriteLine($"\n인벤토리 비운 후 아이템 개수: {inventory.Count}");  // 0

public class GameItem
{
    public string Name { get; }
    public int Power { get; }

    public GameItem(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public override string ToString() => $"{Name} (Power: {Power})";
}


public class MyList<T> : IList<T>
{
    public T[]? array;

    //var stringList = new MyList<string>();
    //stringList[0] = (string)"";
    public T this[int index]
    {
        get { return array[index]; }
        set { array[index] = (T)value; }
    }

    public int Count => array.Length;

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(T item)
    {
        array = new T[Count + 1];
        int index = 0;
        array[index] = item;
        index++;
    }

    public void Clear()
    {
        for (int i = 0; i < Count; i++)
        {
            array[i] = default(T);
        }
        array = default(T[]);
    }

    public bool Contains(T item)
    {
        foreach (T search in array)
        {
            if (search.Equals(item))
                return true;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array == null) throw new ArgumentNullException("array");
        if (arrayIndex < 0) throw new ArgumentOutOfRangeException("index");
        if (arrayIndex >= Count) throw new ArgumentOutOfRangeException("index");

        for (int i = arrayIndex; i < Count; i++)
        {
            this.array[i] = array[i];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)this).GetEnumerator();
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
        bool isInsert = false;
        for (int i = 0; i < Count; ++i)
        {
            T temp = array[0];

            if (i == index)
            {
                //크기 한 칸 늘리기
                //?
                //삽입하기
                temp = array[i];
                array[index] = item;

            }
            //뒤로 밀기
            array[i + 1] = array[i];//@   
        }
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        array[index] = default;
        for (int i = index; i < Count -1 ; i++)
        {
            array[i] = array[i + 1];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
