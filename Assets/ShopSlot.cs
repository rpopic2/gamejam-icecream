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
    
    
    private bool m_isSoldOut = false;
    private string temp_Name;
    
    //raw data
    private ConeEntity m_ConeEntity = null;
    private FlavorEntity m_FlavorEntity = null;
    private ToppingEntity m_toppingEntity = null;

    //public IceCreamEntity IceCreamData { get; set; }

    public void SetShopSlot(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Cone:
                break;
            case ItemType.Flavor:
                break;
            case ItemType.Topping:
                break;
                
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener((() => ButtonClickAction(temp_Name)));
    }

    void ButtonClickAction(string itemName)
    {
        
    }
}
