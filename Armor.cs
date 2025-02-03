using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Armor: Item
    {
        public int def { get; set; }
        public Armor(string name, int def, string info, int price, bool isSetting) : base(name, info, price)
        {
            this.def = def;
            this.isSetting = isSetting;
            
        }
        public override void GetInfo(bool isSell)
        {
            Console.Write($"{name}\t| 방어력 +{def} | {info}");
            if (isSell) Console.WriteLine($" | {price * 0.85} G");
            else Console.WriteLine();
        }
    }
}
