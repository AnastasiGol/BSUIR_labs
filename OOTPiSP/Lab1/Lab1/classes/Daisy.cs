﻿namespace Lab1;

public class Daisy : WildFlower
{
    public bool HasMedicinalProperties { get; set; }
    public string HeightCategory { get; set; }
    public Daisy()
    {
        PictureURL = "images//png-transparent-common-daisy-flower-daisy-family-transvaal-daisy-small-daisy-plant-stem-chamomile-tulip.png";
        Name = "Daisy";
        
    }
    

    public override string ToString()
    {
        return base.ToString() + $", Has Medicinal Properties: {HasMedicinalProperties}, Height Category: {HeightCategory}";
    }
    
    public override Flower Clone() => (Flower)MemberwiseClone();


    
    
}