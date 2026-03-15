using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata.Models
{
    internal class BaseItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public BaseItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        /// <summary>
        /// Update the items Sellin and Quality values according to the rules.
        /// </summary>
        public void Update()
        {
            UpdateQuality();
            UpdateSellin();
        }

        /// <summary>
        /// Base Update Quality method for a normal item. Reduces quality by 1, and if the sell by date has passed reduces quality by 2.
        /// </summary>
        public virtual void UpdateQuality()
        {
            // Checking if quality is below 0 before i start modifying, I noticed that it wasnt always being reset to 0 in the original code
            // UpdateQuality_QualityWouldBeNegative_ReturnQualityOf0 her is the test case that covers it. I think this is a potential mistake in the original
            if (Quality > 0)
            {
                // Base reduction
                --Quality;

                // Expired Reduction
                if (SellIn <= 0)
                {
                    --Quality;
                }

                // Reset Quality to 0 as it cannot be below it
                if (Quality < 0)
                {
                    Quality = 0;
                }
            }
        }

        /// <summary>
        /// Base Update Sellin method for a normal item. Reduces Sellin by 1.
        /// </summary>
        public virtual void UpdateSellin()
        {
            --SellIn;
        }
    }
}
