using System;
using System.Collections.Generic;

[Serializable]
public class IceCreamEntity
{
    public long UniqueId;
    public string Name;
    public long Price;
    public ConeType ConeType;
    public FlavorType FlavorType1;
    public FlavorType FlavorType2;
    public FlavorType FlavorType3;
    public ToppingType ToppingType1;
    public ToppingType ToppingType2;
    public ToppingType ToppingType3;
}

public class IceCream
{
    public long UniqueId { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public ConeType ConeType { get; set; }
    public List<FlavorType> FlavorTypes { get; set; }
    public List<ToppingType> ToppingTypes { get; set; }

    public IceCream(long uniqueId, string name, long price,
        ConeType coneType, 
        FlavorType flavorType1, FlavorType flavorType2, FlavorType flavorType3,
        ToppingType toppingType1, ToppingType toppingType2, ToppingType toppingType3)
    {
        UniqueId = uniqueId;
        Name = name;
        Price = price;

        ConeType = coneType;
        FlavorTypes = new List<FlavorType>();
        ToppingTypes = new List<ToppingType>();

        if (flavorType1 != FlavorType.None)
            FlavorTypes.Add(flavorType1);
        if (flavorType2 != FlavorType.None)
            FlavorTypes.Add(flavorType2);
        if (flavorType3 != FlavorType.None)
            FlavorTypes.Add(flavorType3);

        if (toppingType1 != ToppingType.None)
            ToppingTypes.Add(toppingType1);
        if (toppingType2 != ToppingType.None)
            ToppingTypes.Add(toppingType2);
        if (toppingType3 != ToppingType.None)
            ToppingTypes.Add(toppingType3);
    }
}