namespace Lab1;

abstract class GardenFlower : Flower
{
    public string Season{get;set;}
    public string Pruning{get;set;}
    
    public override string ToString()
    {
        return base.ToString() + $"Season: {Season}, Pruning: {Pruning}, ";
    }


}