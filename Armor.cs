﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Armor: Item
    {
        public double def { get; set; }
        public Armor(string name, double def, string info, int price, bool isSetting) : base(name, info, price)
        {
            this.def = def;
            this.isSetting = isSetting;
            
        }
        public override void GetInfo()
        {
            Console.WriteLine($"{name}\t| 방어력 +{def} | {info}");
        }
    }
}
