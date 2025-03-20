namespace Lab1;

class Tulip : GardenFlower
{
    public bool IsBulbous{ get; set; }
    public string BloomPeriod{ get; set; }
    

    public Tulip()
    {
        PictureURL = "images//c50af48d851c3c830c30a9da4cc45c7b.png";
        Name = "Tulip";
    }

    public override string ToString()
    {
        return base.ToString() + $"Bulbous: {IsBulbous}, Bloom Period: {BloomPeriod}";
    }


}