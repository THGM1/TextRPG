using System.ComponentModel.Design;
using System.Data;

namespace TextRPG
{
    internal class GameManager
    {
        static string[] menus = { "상태 보기", "인벤토리", "상점", "휴식하기" };
        static Dictionary<int, Action> menuAction = new Dictionary<int, Action>
        {
            { 1, ShowStatus },
            {2, ShowInventory },
            {3, ShowShop },
            {4, ShowRest }
        };
        static string[] invenMenu = { "장착 관리", "나가기" };
        static string[] shopMenu = { "나가기", "아이템 구매", "아이템 판매" };
        static Player player;
        static Shop shop;
        static void Main(string[] args)
        {

            Start();
            Menu();

        }
        static void Start()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            CreatePlayer();

            shop = new Shop(); // 상점

            EquipItems();

        }
        static void CreatePlayer() // 플레이어 생성
        {
            if (player == null)
            {
                Console.Write("이름을 입력해주세요: ");
                string name = Console.ReadLine();
                Console.Write("직업을 입력해주세요: ");
                string job = Console.ReadLine();
                player = new Player(name, job);
            }
        }
        static void EquipItems() // 기본 아이템 지급
        {
            Armor item1 = new Armor("무쇠갑옷", 5, "무쇠로 만들어져 튼튼한 갑옷", 2000, false);
            Weapon item2 = new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창", 2500, false);
            Weapon item3 = new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검", 600, false);
            player.inventory.Add(item1);
            player.inventory.Add(item2);
            player.inventory.Add(item3);

            player.EquipItem(item1);
            player.EquipItem(item2);
        }
        static void Menu() // 기본 메뉴
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
                if (int.TryParse(input, out int choice) && menuAction.TryGetValue(choice, out Action action))
                {
                    action.Invoke();
                }
                else
                {
                    Console.WriteLine("다시 입력하세요.");
                }
                //switch (input)
                //{
                //    case "1":
                //        ShowStatus();
                //        break;
                //    case "2":
                //        ShowInventory();
                //        break;
                //    case "3":
                //        ShowShop();
                //        break;
                //    case "4":
                //        ShowRest();
                //        break;
                //    default:
                //        Console.WriteLine("다시 입력하세요");
                //        break;
                //}
            }
        }
        static void ShowStatus() //1. 상태보기
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
        static void ShowInventory() //2.인벤토리
        {
            Console.WriteLine("[아이템 목록]\n");
            foreach(Item item in player.inventory)
            {
                Console.Write("- ");
                if (item.isSetting)
                {
                    Console.Write("[E]");
                }
                item.GetInfo(false);
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

        public static void ShowSetting() //2_1. 장착 관리
        {
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            while (true)
            {
                Console.WriteLine("[아이템 목록]\n");
                int i = 1;
                foreach (Item item in player.inventory)
                {
                    Console.Write($"- {i}. ");
                    if (item.isSetting)
                    {
                        Console.Write("[E]");
                    }
                    item.GetInfo(false);
                    i++;
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine("\n원하시는 행동을 입력해주세요");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    ShowInventory();
                    return;
                }
                else if (int.TryParse(input, out int choice) && choice > 0 && choice <= player.inventory.Count)
                {
                    Item selectedItem = player.inventory[choice - 1];
                    if (selectedItem.isSetting)
                    {
                        selectedItem.setting(); // 이미 장착된 아이템이면 해제
                        Console.WriteLine($"{selectedItem.name}을 장착 해제했습니다.");
                    }
                    else player.EquipItem(selectedItem);
                }
                else
                {
                    Console.WriteLine("다시 입력하세요.");
                }
            }
            
        }
        
        public static void ShowShop() // 3. 상점
        {
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("[보유 골드]\n{0}\n", player.gold);
            Console.WriteLine("[아이템 목록]\n");
            shop.ShowItems(player, false);
            Console.WriteLine();
            for(int i = 1; i < shopMenu.Length; i++)
            {
                Console.WriteLine($"{i}. {shopMenu[i]}");
            }
            Console.WriteLine("0. 나가기");
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
                    case "2":
                        ShowSell();
                        break;
                    default:
                        Console.WriteLine("다시 입력하세요.");
                        break;
                }
            }

        }
        public static void ShowBuy() // 3_1. 아이템 구매
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
                else if (input > shop.items.Count) Console.WriteLine("다시 입력하세요");
                else
                {
                    shop.BuyItmes(player, input);
                }
            }
        }
        public static void ShowSell() //3_2. 아이템 판매
        {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            while (true)
            {
                Console.WriteLine("[보유 골드]\n{0}\n", player.gold);
                Console.WriteLine("[아이템 목록]\n");
                foreach (Item item in player.inventory)
                {
                    Console.Write("- ");
                    if (item.isSetting)
                    {
                        Console.Write("[E]");
                    }
                    item.GetInfo(true);
                }
                Console.WriteLine("\n0. 나가기\n");
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    ShowShop();
                    break;
                }
                else if (input > player.inventory.Count) Console.WriteLine("다시 입력하세요");
                else shop.SellItems(player, input);
            }
            
        }
        public static void ShowRest() //4. 휴식하기
        {
            Console.WriteLine("\n휴식하기\n500G를 내면 체력을 회복할 수 있습니다. (보유 골드: {0} G)", player.gold);


            while (true)
            {
                Console.WriteLine("1. 휴식하기\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                switch (Console.ReadLine())
                {
                    case "0":
                        Menu();
                        break;
                    case "1":
                        player.Rest();
                        break;
                    default:
                        Console.WriteLine("다시 입력해주세요.");
                        break;
                }
            }
        }
    }
}
