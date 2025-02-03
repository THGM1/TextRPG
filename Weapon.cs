using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Weapon: Item
    {
        public double atk {  get; set; }
        public Weapon(string name, double atk, string info, int price, bool isSetting): base(name, info, price)
        {
            this.atk = atk;
            this.isSetting = isSetting;
        }
        public override void GetInfo(bool isSell)
        {
            Console.Write($"{name}\t| 공격력 +{atk} | {info}");
            if (isSell) Console.WriteLine($" | {price * 0.85} G");
            else Console.WriteLine();
        }
    }
}
