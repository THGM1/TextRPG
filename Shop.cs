using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        public List<Item> items;

        public Shop()
        {
            items = new List<Item> {
                new Armor("수련자 갑옷", 5, "수련에 도움을 주는 갑옷", 1000, false),
                new Armor("무쇠 갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷", 2000, false),
                new Armor("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷", 3500, false),
                new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검", 600, false),
                new Weapon("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼", 1500, false),
                new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용헀다는 전설의 창", 2500, false)
            };
            
        }
        public void ShowItems(Player player, bool buy)
        {
            int i = 1;
            foreach (Item item in items)
            {
                bool isOwned = player.inventory.Any(i => i.name == item.name);
                if (buy) Console.Write("- " + i);
                else Console.Write("-");

                if (item is Weapon w)
                {
                    Console.Write($" {w.name}  | +{w.atk} | {w.info}");
                }
                else if(item is Armor a)
                {
                    Console.Write($" {a.name}  | +{a.def} | {a.info}");
                }

                if (isOwned)
                {
                    Console.WriteLine(" | 구매완료");
                }
                else
                {
                    Console.WriteLine($" | {item.price} G");
                }
                i++;
            }
        }
        public void BuyItmes(Player player, int input)
        { 
                Item selectedItem = items[input - 1];
                if (input > items.Count) Console.WriteLine("다시 입력하세요");
                
                if (player.inventory.Any(i => i.name == selectedItem.name))
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }

                else if (selectedItem.price <= player.gold)
                {
                    Console.WriteLine($"'{selectedItem.name}'을(를) 구매했습니다.");
                    player.gold -= selectedItem.price;
                    player.inventory.Add(selectedItem);
                    items.RemoveAt(input - 1);
                    
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
            }
            
    }
}
