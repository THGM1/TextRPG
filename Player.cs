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
        public List<Item> inventory; //인벤토리

        public Player(string name, string job)
        {
            this.name = name;
            this.job = job;
            this.atk = 10;
            this.def = 5;
            this.hp = 100;
            this.gold = 1500;
            this.inventory = new List<Item>();
        }
        public void getPlayer()
        {
            double totalAtk = atk;
            double totalDef = def;
            foreach (Item item in inventory)
            {
                if (item.isSetting)
                {
                    if (item is Weapon w)
                        totalAtk += w.atk;
                    else if (item is Armor a)
                        totalDef += a.def;
                }
            }
            Console.WriteLine($"Lv. {level}");
            Console.WriteLine($"{name} ({job})");

            Console.Write($"공격력: {totalAtk}  ");
            if (totalAtk != atk) Console.Write($"(+ {totalAtk - atk})");
            Console.WriteLine();
            Console.Write($"방어력: {totalDef}  ");
            if (totalDef != def) Console.Write($"(+ {totalDef - def})");

            Console.WriteLine();
            Console.WriteLine($"체력: {hp}");
            Console.WriteLine($"Gold: {gold} G");
        }

        public void UpdateStatus()
        {
            foreach (Item item in inventory)
            {
                if(item is Weapon w)
                {
                    atk += w.atk;
                }
                else if(item is Armor a)
                {
                    def += a.def;
                }
            }
        }
    }
}
