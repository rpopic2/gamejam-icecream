using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image m_IconImg;
    [SerializeField] private TMP_Text m_NameText;
    [SerializeField] private Image m_CoinIconImg;
    [SerializeField] private TMP_Text m_PriceText;

    private ItemType m_ItemType;
    public ItemType ItemType => m_ItemType;

    private bool m_isSoldOut = false;
    
    private string m_NameString;
    private int m_PurchasePrice;
    private string m_IconString;

    public int PurchasePrice => m_PurchasePrice;
    
    //raw data
    private ConeEntity m_ConeEntity = null;
    private FlavorEntity m_FlavorEntity = null;
    private ToppingEntity m_toppingEntity = null;

    public ConeEntity ConeEntity => m_ConeEntity;
    public FlavorEntity FlavorEntity => m_FlavorEntity;
    public ToppingEntity ToppingEntity => m_toppingEntity;
    

    public void SetShopSlot(ConeType cone)
    {
        m_ItemType = ItemType.Cone;
        m_ConeEntity = DataManager.Instance.InGameData.GetConeEntityFromConeType(cone);

        m_NameString = m_ConeEntity.NameString;
        m_PurchasePrice = (int)m_ConeEntity.PurchasePrice;
        m_IconString = m_ConeEntity.Icon;

        SetSlotTextAndIcon();
    }
    
    public void SetShopSlot(FlavorType flavor)
    {
        m_ItemType = ItemType.Flavor;
        m_FlavorEntity = DataManager.Instance.InGameData.GetFlavorEntityFromFlavorType(flavor);

        m_NameString = m_FlavorEntity.NameString;
        m_PurchasePrice = (int)m_FlavorEntity.PurchasePrice;
        m_IconString = m_FlavorEntity.Icon;

        SetSlotTextAndIcon();
    }

    public void SetShopSlot(ToppingType topping)
    {
        m_ItemType = ItemType.Topping;
        m_toppingEntity = DataManager.Instance.InGameData.GetToppingEntityFromToppingType(topping);
        
        m_NameString = m_toppingEntity.NameString;
        m_PurchasePrice = (int)m_toppingEntity.PurchasePrice;
        m_IconString = m_toppingEntity.Icon;

        SetSlotTextAndIcon();
    }

    public void SetSlotTextAndIcon()
    {
        m_NameText.text = m_NameString;
        m_PriceText.text = m_PurchasePrice.ToString();
        
        //TODO
        // Change Icon Img
        
    }
}
