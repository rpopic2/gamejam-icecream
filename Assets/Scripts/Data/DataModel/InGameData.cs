
using System.Collections.Generic;
using System;
using UnityEngine;

/// <summary>
/// 판매할 때 사용할 데이터들
/// 손님, 아이스크림, 주문
/// </summary>
public class InGameData : DataBase 
{
    [SerializeField] private CustomerData CustomerData;
    [SerializeField] private CustomerTypeData CustomerTypeData;

    [SerializeField] private ConeData ConeData;
    [SerializeField] private FlavorData FlavorData;
    [SerializeField] private ToppingData ToppingData;

    [SerializeField] private OrderData OrderData;
    [SerializeField] private ReactionData ReactionData;

    // Row Data
    private Dictionary<BodyType, CustomerParse> CustomerEntityDict = new Dictionary<BodyType, CustomerParse>();
    private List<CustomerTypeEntity> CustomerTypeEntityList = new List<CustomerTypeEntity>();

    private List<ConeEntity> ConeEntityList = new List<ConeEntity>();
    private List<FlavorEntity> FlavorEntityList = new List<FlavorEntity>();
    private List<ToppingEntity> ToppingEntityList = new List<ToppingEntity>();

    private List<OrderEntity> OrderEntityList = new List<OrderEntity>();
    private List<ReactionEntity> ReactionEntityList = new List<ReactionEntity>();

    // Processed Data
    public List<Customer> CustomerDataList = new List<Customer>();
    public List<IceCream> IceCreamDataList = new List<IceCream>();
    public List<Order> OrderDataList = new List<Order>();


    public override void LowDataLoad()
    {
        CustomerEntityDict.Clear();

        foreach (var data in CustomerData.CustomerDatas)
        {
            if (!CustomerEntityDict.ContainsKey(data.BodyTpe))
            {
                CustomerEntityDict.Add(data.BodyTpe, new CustomerParse(data));
            }
            else
            {
                Debug.Log($"CustomerEntityDict Duplicate {data.BodyTpe}");
            }
        }

        CustomerTypeEntityList.Clear();

        foreach (var data in CustomerTypeData.CustomerTypeDatas)
        {
            CustomerTypeEntityList.Add(data.Clone());
        }

        ConeEntityList.Clear();

        foreach (var data in ConeData.ConeDatas)
        {
            ConeEntityList.Add(data.Clone());
        }

        FlavorEntityList.Clear();

        foreach (var data in FlavorData.FlavorDatas)
        {
            FlavorEntityList.Add(data.Clone());
        }

        ToppingEntityList.Clear();

        foreach (var data in ToppingData.ToppingDatas)
        {
            ToppingEntityList.Add(data.Clone());
        }

        OrderEntityList.Clear();

        foreach (var data in OrderData.OrderDatas)
        {
            OrderEntityList.Add(data.Clone());
        }

        ReactionEntityList.Clear();

        foreach (var data in ReactionData.ReactionDatas)
        {
            ReactionEntityList.Add(data.Clone());
        }
    }

    public override void ProcessedDataLoad()
    {
        CustomerDataList.Clear();
        {
            foreach (var entity in CustomerTypeEntityList)
            {
                if (CustomerEntityDict.TryGetValue(entity.BodyType, out var customerParse))
                {
                    customerParse.SkinList.ForEach(skin =>
                    customerParse.HairList.ForEach(hair =>
                    customerParse.FaceList.ForEach(face =>
                    customerParse.ClothesList.ForEach(clothes => CustomerDataList.Add(new Customer 
                    {
                        BodyType = entity.BodyType,
                        Skin = skin,
                        Hair = hair,
                        Face = face,
                        Clothes = clothes,
                    })))));
                }
            }

            Debug.Log($"Create Customer Pool : {CustomerDataList.Count}");
        }

        IceCreamDataList.Clear();
        {
            ConeEntityList.ForEach(cone =>
            FlavorEntityList.ForEach(flavor => IceCreamDataList.Add(new IceCream(cone, flavor))));

            ConeEntityList.ForEach(cone =>
            FlavorEntityList.ForEach(flavor =>
            ToppingEntityList.ForEach(topping => IceCreamDataList.Add(new IceCream(cone, flavor, topping)))));

            ConeEntityList.ForEach(cone =>
            FlavorEntityList.ForEach(flavor =>
            ToppingEntityList.ForEach(topping1 =>
            ToppingEntityList.ForEach(topping2 => IceCreamDataList.Add(new IceCream(cone, flavor, new List<ToppingEntity> { topping1, topping2 }))))));

            Debug.Log($"Create IceCream Pool : {IceCreamDataList.Count}");
        }

        OrderDataList.Clear();
        {
            foreach (var entity in OrderEntityList)
            {
                OrderDataList.Add(new Order(entity));
            }

            Debug.Log($"Create Order List : {OrderDataList.Count}");
        }

        Debug.Log("InGameData Load Done");
    }

    public ConeEntity GetConeEntityFromConeType(ConeType cone)
    {
        ConeEntity coneEntity = ConeEntityList.Find(x => x.ConeType == cone);

        return coneEntity;
    }

    public FlavorEntity GetFlavorEntityFromFlavorType(FlavorType flavor)
    {
        FlavorEntity flavorEntity = FlavorEntityList.Find(x => x.FlavorType == flavor);

        return flavorEntity;
    }

    public ToppingEntity GetToppingEntityFromToppingType(ToppingType topping)
    {
        ToppingEntity toppingEntity = ToppingEntityList.Find(x => x.ToppingType == topping);

        return toppingEntity;
    }
}