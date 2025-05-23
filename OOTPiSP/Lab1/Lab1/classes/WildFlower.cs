﻿namespace Lab1;

public abstract class WildFlower : Flower
{
    public string Habitat{ get; set; }
    public string Size{ get; set; }
    
    public override string ToString()
    {
        return base.ToString() + $"Habitat: {Habitat}, Size: {Size}, ";
    }
}
