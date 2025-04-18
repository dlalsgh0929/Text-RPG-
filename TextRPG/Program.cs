using System;
using static System.Collections.Specialized.BitVector32;

namespace TextRPG
{
    internal class Program
    {
        public class Character 
        {
            private string name;
            private string job = "전사";
            private int level = 1;
            private int attackPower = 10;
            private int defense = 5;
            private int hp = 100;
            private int gold = 15000;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Job
            {
                get { return job; }
                set { job = value; }
            }

            public int Level
            {
                get { return level; }
                set { level = value; }
            }

            public int AttackPower
            {
                get { return attackPower; }
                set { attackPower = value; }
            }

            public int Defense
            {
                get { return defense; }
                set { defense = value; }
            }

            public int Hp
            {
                get { return hp; }
                set { hp = value; }
            }

            public int Gold
            {
                get { return gold; }
                set { gold = value; }
            }

        }

        public class Item
        {
            private string name;
            private string weaponType;
            private int attackPower = 0;
            private int defense = 0;
            private string info;
            private int price;
            private bool isBuy = false;
            private bool isEquip = false;
                            

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string WeaponType
            {
                get { return weaponType; }
                set { weaponType = value; }
            }

            public string Info
            {
                get { return info; }
                set { info = value; }
            }

            public int AttackPower
            {
                get { return attackPower; }
                set { attackPower = value; }
            }

            public int Defense
            {
                get { return defense; }
                set { defense = value; }
            }

            public int Price
            {
                get { return price; }
                set { price = value; }
            }

            public bool IsBuy
            {
                get { return isBuy; }
                set { isBuy = value; }
            }

            public bool IsEquip
            {
                get { return isEquip; }
                set { isEquip = value; }
            }
        }

        public static void MainScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            int action = 0;
            do 
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신것을 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전입장\n5. 휴식하기\n0. 종료하기");

                Console.WriteLine("\n원하시는 행동을 입력하세요");
                Console.Write(">>> ");

                action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        Console.Clear();
                        ConditionScreen(character, myItems, shopItems);
                        break;
                    case 2:
                        Console.Clear();
                        InventoryScreen(character, myItems, shopItems);
                        break;
                    case 3:
                        Console.Clear();
                        ShopScreen(character, myItems, shopItems);
                        break;
                    case 5:
                        Console.Clear();
                        Rest(character, myItems, shopItems);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                        Thread.Sleep(2000);
                        break;
                }

                
            } while (action > 3 || action < 1);
            
        }

        public static void ConditionScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

            if(character.Level < 10)
            {
                Console.WriteLine($"Lv. 0{character.Level}");
            }
            else
            {
                Console.WriteLine($"Lv. {character.Level}");
            }
           
            Console.WriteLine($"{character.Name} ( {character.Job} )");

            if((character.AttackPower - 10) == 0)
            {
                Console.WriteLine($"공격력 : {character.AttackPower}");
            }
            else
            {
                Console.WriteLine($"공격력 : {character.AttackPower} (+{character.AttackPower - 10})");
            }

            if ((character.Defense - 5) == 0)
            {
                Console.WriteLine($"방어력 : {character.Defense}");
            }
            else
            {
                Console.WriteLine($"공격력 : {character.AttackPower} (+{character.Defense - 5})");
            }
            
            Console.WriteLine($"체 력 : {character.Hp}");
            Console.WriteLine($"Gold : {character.Gold} G\n");

            Console.WriteLine("0. 나가기");


            Console.WriteLine("\n원하시는 행동을 입력하세요.");
            Console.Write(">>> ");
            int action = int.Parse(Console.ReadLine());

            if (action == 0)
            {
                MainScreen(character, myItems, shopItems);
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                Thread.Sleep(2000);
            }
        }


        public static void ShopScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점 입니다.");

            Console.WriteLine("\n[보유 골드]");
            Console.WriteLine($"{character.Gold} G");

            Console.WriteLine("\n[아이템 목록]");
            foreach (Item item in shopItems)
            {
                if (item.WeaponType == "방어구" && item.IsBuy == false)
                {
                    Console.WriteLine($"- {item.Name}      | 방어력: +{item.Defense} | {item.Info}     | {item.Price} G");
                }
                else if (item.WeaponType == "방어구" && item.IsBuy == true)
                {
                    Console.WriteLine($"- {item.Name}      | 방어력: +{item.Defense} | {item.Info}     |  구매완료");
                }
                else if (item.WeaponType == "무기" && item.IsBuy == false)
                {
                    Console.WriteLine($"- {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}     | {item.Price} G");
                }
                else if (item.WeaponType == "무기" && item.IsBuy == true)
                {
                    Console.WriteLine($"- {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}     | 구매완료");
                }
            }

            Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력하세요.");
            Console.Write(">>> ");
            int action = int.Parse(Console.ReadLine());

            if (action == 0)
            {
                MainScreen(character, myItems, shopItems);

            }
            else if (action == 1)
            {
                BuyScreen(character, myItems, shopItems);
            }
            else if (action == 2)
            {
                SellScreen(character, myItems, shopItems);
            }
            else 
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                Thread.Sleep(2000);
            }
        }

        public static void BuyScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            do 
            {
                Console.Clear();
                int num = 1;

                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점 입니다.");

                Console.WriteLine("\n[보유 골드]");
                Console.WriteLine($"{character.Gold} G");

                Console.WriteLine("\n[아이템 목록]");

                
                foreach (Item item in shopItems)
                {                    
                    if (item.WeaponType == "방어구" && item.IsBuy == false)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 방어력: +{item.Defense} | {item.Info}     | {item.Price} G");
                    }
                    else if (item.WeaponType == "방어구" && item.IsBuy == true)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 방어력: +{item.Defense} | {item.Info}     |  구매완료");
                    }
                    else if (item.WeaponType == "무기" && item.IsBuy == false)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}     | {item.Price} G");
                    }
                    else if (item.WeaponType == "무기" && item.IsBuy == true)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}     | 구매완료");                       
                    }
                    num++;
                }

                Console.WriteLine("\n0. 나가기");

                Console.WriteLine("\n원하시는 행동을 입력하세요.");
                Console.Write(">>> ");
                int action = int.Parse(Console.ReadLine());

                if (action == 0)
                {
                    MainScreen(character, myItems, shopItems);

                }
                else if(action <= shopItems.Count)
                {
                    if (character.Gold >= shopItems[action - 1].Price && shopItems[action - 1].IsBuy == false)
                    {
                        shopItems[action - 1].IsBuy = true;
                        myItems.Add(shopItems[action - 1]);
                        character.Gold = character.Gold - shopItems[action - 1].Price;
                        Console.WriteLine("구매를 완료했습니다.");
                        Thread.Sleep(2000);
                    }
                    else if (character.Gold < shopItems[action - 1].Price && shopItems[action - 1].IsBuy == false)
                    {
                        Console.WriteLine("Gold 가 부족합니다.");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("이미 구매하신 상품입니다.");
                        Thread.Sleep(2000);
                    }


                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(2000);
                }
            } while (true);
            

        }

        public static void SellScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            do
            {
                Console.Clear();
                int num = 1;

                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점 입니다.");

                Console.WriteLine("\n[보유 골드]");
                Console.WriteLine($"{character.Gold} G");

                Console.WriteLine("\n[아이템 목록]");

                
                foreach (Item item in myItems)
                {
                    if (item.WeaponType == "방어구" && item.IsEquip == false)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 방어력: +{item.Defense} | {item.Info}");
                    }
                    else if (item.WeaponType == "방어구" && item.IsEquip == true)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 방어력: +{item.Defense} | {item.Info}");
                    }
                    else if (item.WeaponType == "무기" && item.IsEquip == false)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}");
                    }
                    else if (item.WeaponType == "무기" && item.IsEquip == true)
                    {
                        Console.WriteLine($"- {num} {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}");
                    }
                    num++;
                }

                Console.WriteLine("\n0. 나가기");

                Console.WriteLine("\n원하시는 행동을 입력하세요.");
                Console.Write(">>> ");
                int action = int.Parse(Console.ReadLine());

                if (action == 0)
                {
                    MainScreen(character, myItems, shopItems);

                }
                else if (action <= myItems.Count)
                {
                    for (int i = 0; i < shopItems.Count; i++)
                    {
                        if (shopItems[i].Name == myItems[action - 1].Name)
                        {
                            shopItems[i].IsBuy = false;
                        }
                    }
                    double sellGold = (double)myItems[action - 1].Price * 0.85f;
                    character.Gold += (int)sellGold;
                    myItems.Remove(myItems[action - 1]);

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(2000);
                }
            } while (true);
        }


        public static void InventoryScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine("\n[아이템 목록]\n");

            if(myItems.Count > 0)
            {
                foreach (Item item in myItems)
                {
                    if (item.WeaponType == "방어구" && item.IsEquip == false)
                    {
                        Console.WriteLine($"- {item.Name}      | 방어력: +{item.Defense} | {item.Info}");
                    }
                    else if (item.WeaponType == "방어구" && item.IsEquip == true)
                    {
                        Console.WriteLine($"- {item.Name}      | 방어력: +{item.Defense} | {item.Info}");
                    }
                    else if (item.WeaponType == "무기" && item.IsEquip == false)
                    {
                        Console.WriteLine($"- {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}");
                    }
                    else if (item.WeaponType == "무기" && item.IsEquip == true)
                    {
                        Console.WriteLine($"- {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}");
                    }
                }
            }

            Console.WriteLine("\n1. 장착관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine("\n원하시는 행동을 입력하세요.");
            Console.Write(">>> ");
            int action = int.Parse(Console.ReadLine());

            if (action == 0)
            {
                MainScreen(character, myItems, shopItems);
            }
            else
            {
                EquipScreen(character, myItems, shopItems);
            }
               
        }

        public static void EquipScreen(Character character, List<Item> myItems, List<Item> shopItems)
        {
            do
            {
                Console.Clear();
                int num = 1;

                Console.WriteLine("인벤토리 - 장착관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

                Console.WriteLine("\n[아이템 목록]\n");

                if (myItems.Count > 0)
                {
                    foreach (Item item in myItems)
                    {
                        if (item.WeaponType == "방어구" && item.IsEquip == false)
                        {
                            Console.WriteLine($"- {num} {item.Name}      | 방어력: +{item.Defense} | {item.Info}");
                        }
                        else if (item.WeaponType == "방어구" && item.IsEquip == true)
                        {
                            Console.WriteLine($"- {num} [E]{item.Name}      | 방어력: +{item.Defense} | {item.Info}");
                        }
                        else if (item.WeaponType == "무기" && item.IsEquip == false)
                        {
                            Console.WriteLine($"- {num} {item.Name}      | 공격력: +{item.AttackPower} | {item.Info}");
                        }
                        else if (item.WeaponType == "무기" && item.IsEquip == true)
                        {
                            Console.WriteLine($"- {num} [E]{item.Name}      | 공격력: +{item.AttackPower} | {item.Info}");
                        }
                        num++;
                    }
                }

                Console.WriteLine("\n0. 나가기");

                Console.WriteLine("\n원하시는 행동을 입력하세요.");
                Console.Write(">>> ");
                int action = int.Parse(Console.ReadLine());

                if (action == 0)
                {
                    MainScreen(character, myItems, shopItems);
                }
                else if (action <= myItems.Count && myItems[action - 1].IsEquip == false)
                {
                    
                    
                    if (myItems[action - 1].WeaponType == "방어구")
                    {
                        foreach (Item item in myItems)
                        {
                            if (item.IsEquip == true && item.WeaponType == "방어구")
                            {
                                item.IsEquip = false;
                                character.Defense -= item.Defense;

                            }
                        }

                        myItems[action - 1].IsEquip = true;
                        character.Defense += myItems[action - 1].Defense;
                    }
                    else if (myItems[action - 1].WeaponType == "무기")
                    {
                        foreach (Item item in myItems)
                        {
                            if (item.IsEquip == true && item.WeaponType == "무기")
                            {
                                item.IsEquip = false;
                                character.AttackPower -= item.AttackPower;
                            }
                        }

                        myItems[action - 1].IsEquip = true;
                        character.AttackPower += myItems[action - 1].AttackPower;
                    }
                }
                else if (action <= myItems.Count && myItems[action - 1].IsEquip == true)
                {
                    if (myItems[action - 1].WeaponType == "방어구")
                    {
                        myItems[action - 1].IsEquip = false;
                        character.Defense -= myItems[action - 1].Defense;
                    }
                    else if (myItems[action - 1].WeaponType == "무기")
                    {
                        myItems[action - 1].IsEquip = false;
                        character.AttackPower -= myItems[action - 1].AttackPower;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(2000);
                }
            } while (true);
            

        }

        public static void Rest(Character character, List<Item> myItems, List<Item> shopItems)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("휴식하기");
                Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {character.Gold} G)");

                Console.WriteLine("\n1. 휴식하기");
                Console.WriteLine("0. 나가기");

                Console.WriteLine("\n원하시는 행동을 입력하세요.");
                Console.Write(">>> ");
                int action = int.Parse(Console.ReadLine());

                if (action == 0)
                {
                    MainScreen(character, myItems, shopItems);
                }
                else if(action == 1)
                {
                    character.Hp = 100;
                    character.Gold -= 500;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(2000);
                }
            } while (true);
        }


        public static void Main(string[] args)
        {
            Character character = new Character();
            Console.Write("닉네임을 입력해주세요: ");
            character.Name = Console.ReadLine();

            List<Item> shopItems = new List<Item>();
            shopItems.Add(new Item {Name = "수련자 갑옷", WeaponType = "방어구", Defense = 5, Info = "수련에 도움을 주는 갑옷입니다.", Price = 1000});
            shopItems.Add(new Item { Name = "무쇠갑옷", WeaponType = "방어구", Defense = 9, Info = "무쇠로 만들어져 튼튼한 갑옷입니다.", Price = 1800 });
            shopItems.Add(new Item { Name = "스파르타의 갑옷", WeaponType = "방어구", Defense = 15, Info = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", Price = 3500 });
            shopItems.Add(new Item { Name = "기생의 갑옷", WeaponType = "방어구", Defense = 27, Info = "착용자에게 기생하여 강한 힘을 주는 갑옷입니다.", Price = 4500 });
            shopItems.Add(new Item { Name = "낡은 검", WeaponType = "무기", AttackPower = 2, Info = "쉽게 볼 수 있는 낡은 검 입니다.", Price = 600 });
            shopItems.Add(new Item { Name = "청동 도끼", WeaponType = "무기", AttackPower = 5, Info = "어디선가 사용됐던거 같은 도끼입니다.", Price = 1500 });
            shopItems.Add(new Item { Name = "스파르타의 창", WeaponType = "무기", AttackPower = 7, Info = "스파르타의 전사들이 사용했다는 전설의 창입니다.", Price = 3500 });
            shopItems.Add(new Item { Name = "잔다르크의 깃발", WeaponType = "무기", AttackPower = 15, Info = "잔다르크가 사용했다고 전해지는 깃창, 신의 가호를 받아 아군은 지키며 적들은 섬멸한다.", Price = 5000 });

            List<Item> myItems = new List<Item>();

            MainScreen(character, myItems, shopItems);
        }
    }
}
