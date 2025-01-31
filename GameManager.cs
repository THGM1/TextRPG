using System.ComponentModel.Design;
using System.Data;

namespace TextRPG
{
    internal class GameManager
    {
        static string[] menus = { "상태 보기", "인벤토리", "상점" };
        static string[] invenMenu = { "장착 관리", "나가기" };
        static Player player;
        static void Main(string[] args)
        {

            Start();


        }
        static void Start()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            if(player == null)
            {
                Console.Write("이름을 입력해주세요: ");
                string name = Console.ReadLine();
                Console.Write("직업을 입력해주세요: ");
                string job = Console.ReadLine();
                player = new Player(name, job);
            }
            Armor item1 = new Armor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷", true);
            Weapon item2 = new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창", true);
            Weapon item3 = new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검", false);
            Weapon item4 = new Weapon("검", 2, "검", false);
            player.inventory.Add(item1);
            player.inventory.Add(item2);
            player.inventory.Add(item3);

            Menu();

        }
        static void Menu()
        {
            Console.WriteLine();
            for (int i = 0; i < menus.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menus[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowStatus();
                        break;
                    case "2":
                        ShowInventory();
                        break;
                    default:
                        Console.WriteLine("다시 입력하세요");
                        break;
                }
            }
        }
        static void ShowStatus()
        {
            Console.WriteLine();
            player.getPlayer();
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            while (true)
            {
                if (input == "0")
                {
                    Menu();
                    break;
                }
                else
                {
                    Console.WriteLine("다시 입력하세요");
                }
            }

        }
        static void ShowInventory()
        {
            Console.WriteLine("[아이템 목록]\n");
            foreach(Item item in player.inventory)
            {
                Console.Write("- ");
                if (item.isSetting)
                {
                    Console.Write("[E]");
                }
                item.GetInfo();
            }
            Console.WriteLine();
            for (int i = 0; i < invenMenu.Length; i++)
            {
                Console.WriteLine($"{i+1}. {invenMenu[i]}");
            }
            Console.WriteLine("\n 원하시는 행동을 입력해주세요");
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowSetting();
                        break;
                    case "2":
                        Menu();
                        break;
                    default:
                        Console.WriteLine("다시 입력하세요.");
                        break;
                }
            }

        }

        static void ShowSetting()
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");
            int i = 1;
            foreach (Item item in player.inventory)
            {
                Console.Write($"- {i}. ");
                if (item.isSetting)
                {
                    Console.Write("[E]");
                }
                item.GetInfo();
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            while (true)
            {
                Console.WriteLine("\n 원하시는 행동을 입력해주세요");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    ShowInventory();
                    break;
                }
                else if (int.Parse(input) <= player.inventory.Count)
                {
                    player.inventory[int.Parse(input) - 1].setting();
                    ShowSetting();
                    break;
                }
                else
                {
                    Console.WriteLine("다시 입력하세요.");
                }

            }
        }
    }
}
