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
        public int gold; //골드
        public List<Item> inventory; //인벤토리
        public Weapon equippedWeapon; // 착용한 무기
        public Armor equippedArmor; // 착용한 방어구

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

        //public void UpdateStatus()
        //{
        //    foreach (Item item in inventory)
        //    {
        //        if(item is Weapon w)
        //        {
        //            atk += w.atk;
        //        }
        //        else if(item is Armor a)
        //        {
        //            def += a.def;
        //        }
        //    }
        //}
        
        public void Rest() // 휴식
        {
            if(gold >= 500)
            {
                gold -= 500; //500G 차감
                hp = 100; // 체력 100까지 회복
                Console.WriteLine("휴식을 완료했습니다.");
                Console.WriteLine("남은 골드: {0}", gold);
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
            }
        }
        public void EquipItem(Item item)
        {
            if (item is Weapon w)
            {
                if (equippedWeapon != null) // 기존 무기 해제
                {
                    equippedWeapon.isSetting = false;
                    Console.WriteLine($"{equippedWeapon.name}을(를) 장착 해제했습니다.");
                }
                equippedWeapon = w; // 새 무기 장착
                w.isSetting = true;
                Console.WriteLine($"{w.name}을(를) 장착했습니다.");
            }
            else if (item is Armor a)
            {
                if (equippedArmor != null) // 기존 방어구 해제
                {
                    equippedArmor.isSetting = false;
                    Console.WriteLine($"{equippedArmor.name}을(를) 장착 해제했습니다.");
                }
                equippedArmor = a; // 새 방어구 장착
                a.isSetting = true;
                Console.WriteLine($"{a.name}을(를) 장착했습니다.");
            }
            else Console.WriteLine("이 아이템은 장착할 수 없습니다.");
        }
    }
}
