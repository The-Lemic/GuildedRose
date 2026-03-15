namespace GildedRoseKata.Models
{
    internal class Sulfuras(string name, int sellIn, int quality) : BaseItem(name, sellIn, quality)
    {
        /// <summary>
        /// Update Quality for Sulfuras. Sulfuras never has to be sold or decreases in Quality.
        /// </summary>
        public override void UpdateQuality()
        {
            // Do Nothing
        }
        /// <summary>
        /// Update Sellin for Sulfuras. Sulfuras never has to be sold or decreases in Quality.
        /// </summary>
        public override void UpdateSellin()
        {
            // Do Nothing
        }
    }
}