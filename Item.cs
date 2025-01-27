using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    abstract class Item
    {
        public string name { get; set; }
        public string info { get; set; }
        public bool isSetting {  get; set; }
        public Item(string name, string info, bool isSetting)
        {
            this.name = name;
            this.info = info;
            this.isSetting = isSetting;
        }

        public abstract void GetInfo();


    }
}
