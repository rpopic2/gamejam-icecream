using System;
using System.Collections.Generic;

public class IceCreamBaseEntity
{
    public string NameString;
    public long SalePrice;
    public long PurchasePrice;
    public string Icon;
}

public class IceCreamBase
{
    public string NameString;
    public long SalePrice;
    public long PurchasePrice;

    public IceCreamBase(IceCreamBaseEntity data)
    {
        NameString = data.NameString;
        SalePrice = data.SalePrice;
        PurchasePrice = data.PurchasePrice;
    }
}


[Serializable]
public class ConeEntity : IceCreamBaseEntity
{
    public ConeType ConeType;

    public ConeEntity Clone()
    {
        return new ConeEntity
        {
            NameString = NameString,
            ConeType = ConeType,
            SalePrice = SalePrice,
            PurchasePrice = PurchasePrice,
            Icon = Icon,
        };
    }
}

public class Cone : IceCreamBase
{
    public ConeType ConeType;

    public Cone(IceCreamBaseEntity data, ConeType cone) : base(data)
    {
        ConeType = cone;
    }
}

[Serializable]
public class FlavorEntity : IceCreamBaseEntity
{
    public FlavorType FlavorType;

    public FlavorEntity Clone()
    {
        return new FlavorEntity
        {
            NameString = NameString,
            FlavorType = FlavorType,
            SalePrice = SalePrice,
            PurchasePrice = PurchasePrice,
            Icon = Icon,
        };
    }
}

public class Flavor : IceCreamBase
{
    public FlavorType FlavorType;

    public Flavor(IceCreamBaseEntity data, FlavorType flavor) : base(data)
    {
        FlavorType = flavor;
    }
}

[Serializable]
public class ToppingEntity : IceCreamBaseEntity
{
    public ToppingType ToppingType;

    public ToppingEntity Clone()
    {
        return new ToppingEntity
        {
            NameString = NameString,
            ToppingType = ToppingType,
            SalePrice = SalePrice,
            PurchasePrice = PurchasePrice,
            Icon = Icon,
        };
    }
}

public class Topping : IceCreamBase
{
    public ToppingType ToppingType;

    public Topping(IceCreamBaseEntity data, ToppingType topping) : base(data)
    {
        ToppingType = topping;
    }
}