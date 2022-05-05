using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class LootItem
    {
        private int dropRateValue;
        private bool isDefaultItemValue;
        public Item Details { get; set; }
        public int DropRate 
        { 
            get
            { return dropRateValue; }
            set
            { dropRateValue = value; }
        }
        public bool IsDefaultItem 
        {
            get
            {return isDefaultItemValue; }
            set
            { isDefaultItemValue = value; }
        }

        public LootItem(Item details, int dropRate, bool isDefaultItem)
        {
            Details = details;
            DropRate = dropRate;
            IsDefaultItem = isDefaultItem;
        }
    }
}
