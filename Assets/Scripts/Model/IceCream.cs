using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

public class IceCream
{
    public Cone Cone { get; set; }
    public Flavor Flavor { get; set; }
    public List<Topping> Toppings { get; set; }

    public long TotalSalePrice =>
        Cone.SalePrice +
        Flavor.SalePrice +
        Toppings?.Sum(e => e.SalePrice) ?? 0;

    public long TotalPurchasePrice =>
        Cone.PurchasePrice +
        Flavor.PurchasePrice +
        Toppings?.Sum(e => e.PurchasePrice) ?? 0;

    public IceCream(ConeEntity coneEntity, FlavorEntity flavorEntity)
    {
        Cone = new Cone(coneEntity, coneEntity.ConeType);
        Flavor = new Flavor(flavorEntity, flavorEntity.FlavorType);
    }

    public IceCream(ConeEntity coneEntity, FlavorEntity flavorEntity, ToppingEntity toppingEntity)
    {
        Cone = new Cone(coneEntity, coneEntity.ConeType);
        Flavor = new Flavor(flavorEntity, flavorEntity.FlavorType);
        Toppings = new List<Topping>() { new Topping(toppingEntity, toppingEntity.ToppingType)};
    }

    public IceCream(ConeEntity coneEntity, FlavorEntity flavorEntity, List<ToppingEntity> toppingEntity)
    {
        Cone = new Cone(coneEntity, coneEntity.ConeType);
        Flavor = new Flavor(flavorEntity, flavorEntity.FlavorType);
        Toppings = new List<Topping>(toppingEntity.Select(e => new Topping(e, e.ToppingType)));
    }
}