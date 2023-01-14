using System;

[Serializable]
public class OrderEntity
{
    public long ID;
    public OrderType OrderType;
    public string Script;

    public OrderEntity Clone()
    {
        return new OrderEntity()
        {
            ID = ID,
            OrderType = OrderType,
            Script = Script,
        };
    }
}

public class Order
{
    public long ID { get; set; }
    public OrderType OrderType { get; set; }
    public string Script { get; set; }

    public IceCream IceCream { get; set; }

    public Order(OrderEntity data, IceCream iceCream)
    {
        ID = data.ID;
        OrderType = data.OrderType;
        Script = data.Script;

        IceCream = iceCream;
    }

    public string OrderScriptParse()
    {
        switch (OrderType)
        {
            case OrderType.OnlyFlavor:
                return String.Format(Script, IceCream.Flavor.NameString);
            case OrderType.ConeAndFlavor:
                return String.Format(Script, IceCream.Flavor.NameString, IceCream.Cone.NameString);
            case OrderType.ConeAndFlavorWithTopping1:
                return String.Format(Script, IceCream.Flavor.NameString, IceCream.Cone.NameString, IceCream.Toppings[0].NameString);
            case OrderType.ConeAndFlavorWithTopping2:
                return String.Format(Script, IceCream.Flavor.NameString, IceCream.Cone.NameString, IceCream.Toppings[0].NameString, IceCream.Toppings[1].NameString);
            case OrderType.ConeAndFlavorWithTopping3:
                return String.Format(Script, IceCream.Flavor.NameString, IceCream.Cone.NameString, IceCream.Toppings[0].NameString, IceCream.Toppings[1].NameString, IceCream.Toppings[2].NameString);
        }
        return "parse error";
    }
}


