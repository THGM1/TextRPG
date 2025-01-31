using System.ComponentModel.Design;
using System.Data;

namespace TextRPG
{
    internal class GameManager
    {
        static string[] menus = { "상태 보기", "인벤토리", "상점" };
        static string[] invenMenu = { "장착 관리", "나가기" };
        static string[] shopMenu = { "나가기", "아이템 구매" };
        static Player player;
        static Shop shop;
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
            shop = new Shop();

            player.inventory.Add(new Armor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷", 2000, true));
            player.inventory.Add(new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창", 2500, true));
            player.inventory.Add(new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검", 600, false));


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
                    case "3":
                        ShowShop();
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
            Console.WriteLine("\n원하시는 행동을 입력해주세요");
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

        public static void ShowSetting()
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
                Console.WriteLine("\n원하시는 행동을 입력해주세요");
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
        
        public static void ShowShop()
        {
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]\n{0}\n", player.gold);
            Console.WriteLine("[아이템 목록]\n");
            shop.ShowItems(player, false);
            Console.WriteLine();
            for(int i = 0; i < shopMenu.Length; i++)
            {
                Console.WriteLine($"{i}. {shopMenu[i]}");
            }
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "0":
                        Menu();
                        break;
                    case "1":
                        ShowBuy();
                        break;
                    default:
                        Console.WriteLine("다시 입력하세요.");
                        break;
                }
            }

        }
        public static void ShowBuy()
        {
           
            while (true)
            {
                Console.WriteLine("[보유 골드]\n{0}\n", player.gold);
                Console.WriteLine("[아이템 목록]\n");
                shop.ShowItems(player, true);
                Console.WriteLine("\n0. 나가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    ShowShop();
                    break;
                }
                else
                {
                    shop.BuyItmes(player, input);
                }
            }
        }
    }
}
