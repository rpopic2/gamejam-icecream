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

    public Order(OrderEntity data)
    {
        ID = data.ID;
        OrderType = data.OrderType;
        Script = data.Script;
    }

    public string OrderScriptParse(IceCream iceCream, OrderType orderType)
    {
        switch (orderType)
        {
            case OrderType.OnlyFlavor:
                return String.Format(Script, iceCream.Flavor.NameString);
            case OrderType.ConeAndFlavor:
                return String.Format(Script, iceCream.Flavor.NameString, iceCream.Cone.NameString);
            case OrderType.ConeAndFlavorWithTopping1:
            case OrderType.ConeAndFlavorWithTopping2:
            case OrderType.ConeAndFlavorWithTopping3:
                return String.Format(Script, iceCream.Flavor.NameString, iceCream.Cone.NameString, iceCream.Toppings);
        }
        return "parse error";
    }
}


