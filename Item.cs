using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    class Item
    {
        public string name { get; set; }
        public string info { get; set; }
        public bool isSetting {  get; set; }
        public int price { get; set; }
        public Item(string name, string info, int price)
        {
            this.name = name;
            this.info = info;
            this.price = price;
            this.isSetting = false;
        }

        public virtual void GetInfo(bool isSell)
        {
            Console.Write($"{name} | {info}");
            if (isSell) Console.WriteLine($" | {price * 0.85} G");
            else Console.WriteLine();
        }
        
        public void setting()
        {
            isSetting = !isSetting;
        }


    }
}
