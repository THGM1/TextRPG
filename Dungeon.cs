using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Dungeon
    {
        public string name; // 이름
        public int level; // 난이도
        public int reqDef; // 권장 방어력
        public int reward; // 보상 G
        Player player;
        Random rand = new Random();
        public Dungeon(int level, int reqDef)
        {
            this.level = level;
            this.reqDef = reqDef;
            switch (level)
            {
                case 1:
                    name = "쉬운 던전";
                    reward = 1000;
                    break;
                case 2:
                    name = "일반 던전";
                    reward = 1700;
                    break;
                case 3:
                    name = "어려운 던전";
                    reward = 2500;
                    break;
            }
        }

        public int[] Enter(Player player)
        {
            int[] dungeonClear = new int[2] {0,0};
            if (player.def < reqDef) // 권장 방어력보다 작다면
            {
                if (rand.NextDouble() < 0.4)
                {  // 40% 확률로 실패
                    player.hp /= 2;
                    return dungeonClear;
                }
            }
            int sub = reqDef - player.def;
            dungeonClear[0] = rand.Next(20 + sub, 36 + sub);
            player.hp -= dungeonClear[0];

            dungeonClear[1] = reward * (1 + rand.Next(player.atk, player.atk * 2) / 100);
            player.gold += dungeonClear[1];
            return dungeonClear;
        }

        public void Clear(Player player)
        {
            int[] clear = Enter(player);
            Console.WriteLine("축하합니다!!!");
            Console.WriteLine($"{name}을 클리어 하였습니다.");
            Console.WriteLine("\n[탐험 결과]");
            Console.WriteLine($"체력: {player.hp + clear[0]} -> {player.hp}");
            Console.WriteLine($"Gold: {player.gold - clear[1]} G -> {player.gold} G");
        }

    }
}
