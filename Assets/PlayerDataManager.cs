using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{
    [Header("UI")]
    [SerializeField] private TMP_Text m_CoinText;

    [SerializeField] private List<ConeType> m_StartingConeList;
    [SerializeField] private List<FlavorType> m_StartingFlavorList;
    [SerializeField] private List<ToppingType> m_StartingToppingList;
    public int PlayerMoney { get; set; } = 0;

    public List<ConeInventory> ConeInvenList;
    public List<FlavorInventory> FlavorInvenList;
    public List<ToppingInventory> ToppingInvenList;

    private void Start()
    {
        foreach (ConeType var in Enum.GetValues(typeof(ConeType)))
        {
            if (var != ConeType.None)
            {
                ConeInventory cone = new ConeInventory(var);
                if(m_StartingConeList.Contains(var))
                {
                    cone.SetFirstItem();
                }
                ConeInvenList.Add(cone);
            }
        }

        foreach (FlavorType var in Enum.GetValues(typeof(FlavorType)))
        {
            if (var != FlavorType.None)
            {
                FlavorInventory flavor = new FlavorInventory(var);
                if (m_StartingFlavorList.Contains(var))
                {
                    flavor.SetFirstItem();
                }
                FlavorInvenList.Add(flavor);
            }
        }

        foreach (ToppingType var in Enum.GetValues(typeof(ToppingType)))
        {
            if (var != ToppingType.None)
            {
                ToppingInventory topping = new ToppingInventory(var);
                if (m_StartingToppingList.Contains(var))
                {
                    topping.SetFirstItem();
                }
                ToppingInvenList.Add(topping);
            }
        }
    }
}

public class Inventory
{
    private int m_Count;

    public Inventory()
    {
        m_Count = 0;
    }

    public int GetCount()
    {
        return m_Count;
    }

    public void SetFirstItem()
    {
        m_Count = DataManager.Instance.MaxNum;
    }

    public virtual void BuyFromShop()
    {
        m_Count = DataManager.Instance.MaxNum;
    }

    public void UseItem()
    {
        if (m_Count <= 0)
            return;

        m_Count -= 1;
    }
}

public class ConeInventory : Inventory
{
    public ConeType ConeType;

    public ConeInventory(ConeType cone)
    {
        ConeType = cone;
    }

    public override void BuyFromShop()
    {
        base.BuyFromShop();

        long purchasePrice = DataManager.Instance.InGameData.GetConeEntityFromConeType(ConeType).PurchasePrice;

        PlayerDataManager.Instance.PlayerMoney -= (int)purchasePrice;
    }
}


public class FlavorInventory : Inventory
{
    public FlavorType FlavorType;

    public FlavorInventory(FlavorType flavor)
    {
        FlavorType = flavor;
    }
    
    public override void BuyFromShop()
    {
        base.BuyFromShop();

        long purchasePrice = DataManager.Instance.InGameData.GetFlavorEntityFromFlavorType(FlavorType).PurchasePrice;

        PlayerDataManager.Instance.PlayerMoney -= (int)purchasePrice;
    }
}

public class ToppingInventory : Inventory
{
    public ToppingType ToppingType;

    public ToppingInventory(ToppingType topping)
    {
        ToppingType = topping;
    }
    
    public override void BuyFromShop()
    {
        base.BuyFromShop();

        long purchasePrice = DataManager.Instance.InGameData.GetToppingEntityFromToppingType(ToppingType).PurchasePrice;

        PlayerDataManager.Instance.PlayerMoney -= (int)purchasePrice;
    }
}