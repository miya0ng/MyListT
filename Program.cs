// 문자열 리스트 테스트
using System;
using System.Collections;

Console.WriteLine("=== 문자열 리스트 테스트 ===");
var stringList = new MyList<string>();

stringList.Add("검");
stringList.Add("방패");
stringList.Add("물약");

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
//검, 활, 방패, 물약

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
