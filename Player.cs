using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Player
    {
        int level; //레벨
        string name; //이름
        string job; //직업
        double atk; //공격력
        double def; //방어력
        int hp; //체력
        int gold; //골드

        public Player(string name, string job)
        {
            this.name = name;
            this.job = job;
            this.atk = 10;
            this.def = 5;
            this.hp = 100;
            this.gold = 1500;
        }
        public void getPlayer()
        {
            Console.WriteLine($"Lv. {level}");
            Console.WriteLine($"{name} ({job})");
            Console.WriteLine($"공격력: {atk}");
            Console.WriteLine($"방어력: {def}");
            Console.WriteLine($"체력: {hp}");
            Console.WriteLine($"Gold: {gold} G");
        }
        
    }
}
