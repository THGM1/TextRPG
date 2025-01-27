namespace TextRPG
{
    internal class GameManager
    {
        static string[] menus = { "상태 보기", "인벤토리", "상점" };
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
            
            Menu();

        }
        static void Menu()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menus[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowStatus();
                    break;
                case "2":

                    break;
            }
        }
        static void ShowStatus()
        {
            Console.WriteLine();
            player.getPlayer();
            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            string input = Console.ReadLine();
            if(input != null)
            {
                Menu();
            }

        }
    }
}
