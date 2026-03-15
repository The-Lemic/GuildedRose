using System.Collections;

namespace GildedRoseKata.Models
{
    internal class BackstagePasses : BaseItem
    {
        public BackstagePasses(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }
        /// <summary>
        /// Update Quality for Backstage Passes. Increases in quality by 1, and if the sell by date has passed increases in quality by 2. If the sell by date is 10 days or less increases in quality by 2, and if the sell by date is 5 days or less increases in quality by 3.
        /// </summary>
        public override void UpdateQuality()
        {
            // Quality drops to 0 after the concert
            if (SellIn <= 0)
            {
                Quality = 0;
                return;
            }

            if (Quality < 50)
            {
                // Base increase
                Quality += 1;

                // 10 Days out
                if (SellIn <= 10)
                {
                    Quality++;
                }    

                // 5 days or less out
                if (SellIn <= 5)
                {
                    Quality++;
                }
            }
        }
    }
}