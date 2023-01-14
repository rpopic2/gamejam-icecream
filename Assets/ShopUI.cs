using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("ShopUI")]
    //temp
    [SerializeField] private List<ShopSlot> m_ShopSlotList;
    [SerializeField] private ShopPopup m_ShopPopup;

    [SerializeField] private List<Sprite> m_IconList;

    [Header("ForTween")] 
    [SerializeField] private RectTransform m_OutPos;
    [SerializeField] private RectTransform m_InPos;
    [SerializeField] private RectTransform m_ShopUIBG;
    
    private ShopSlot m_SelectedSlot;

    private List<ConeType> m_RandomConeTypeList = new List<ConeType>();
    private List<FlavorType> m_RandomFlavorTypeList = new List<FlavorType>();
    private List<ToppingType> m_RandomToppingTypeList = new List<ToppingType>();
    
    //temp
    private int m_Stage = 1;
    //private int m_Day = 1;
    
    void Start()
    {
        m_ShopPopup.OKButton.onClick.AddListener(PopupOkAction);
        m_ShopPopup.CancelButton.onClick.AddListener(PopupCancelAction);
        SetShopSlotList();
    }

    [ContextMenu("UIIN")]
    public void SetUISlideIn()
    {
        m_ShopUIBG.DOAnchorPos(new Vector2(m_InPos.anchoredPosition.x, m_InPos.anchoredPosition.y), 1.5f);
    }

    [ContextMenu("UIOut")]
    public void SetUISlideOut()
    {
        m_ShopUIBG.DOAnchorPos(new Vector2(m_OutPos.anchoredPosition.x, m_OutPos.anchoredPosition.y), 1.5f);
    }

    public void SetShopSlotList()
    {
        if (m_ShopSlotList.Count == 8)
        {
            SetRandomList(m_Stage, DayCounter.Instance.Day);
            int idx;
            // 1 ~ 8 번 슬롯
            // 1 ~ 3번 : 기본맛 3가지 고정
            m_ShopSlotList[0].SetShopSlot(FlavorType.Strawberry, GetIconSpriteFromString(FlavorType.Strawberry.ToString()));
            m_ShopSlotList[1].SetShopSlot(FlavorType.Chocolate, GetIconSpriteFromString(FlavorType.Chocolate.ToString()));
            m_ShopSlotList[2].SetShopSlot(FlavorType.Vanilla, GetIconSpriteFromString(FlavorType.Vanilla.ToString()));

            //FlavorType.Vanilla.ToString()
            // 4번 : 콘슬롯
            idx = Random.Range(0, m_RandomConeTypeList.Count);
            m_ShopSlotList[3].SetShopSlot(m_RandomConeTypeList[idx], GetIconSpriteFromString(m_RandomConeTypeList[idx].ToString()));

            // 5 ~ 6번 : 추가맛 3가지중 2가지
            idx = Random.Range(0, m_RandomFlavorTypeList.Count);
            m_ShopSlotList[4].SetShopSlot(m_RandomFlavorTypeList[idx], GetIconSpriteFromString(m_RandomFlavorTypeList[idx].ToString()));
            m_RandomFlavorTypeList.RemoveAt(idx);
            
            idx = Random.Range(0, m_RandomFlavorTypeList.Count);
            m_ShopSlotList[5].SetShopSlot(m_RandomFlavorTypeList[idx], GetIconSpriteFromString(m_RandomFlavorTypeList[idx].ToString()));
            
            // 7 ~ 8번 : 토핑 2가지
            // 토핑리스트 비어있으면 빈 슬롯으로

            if (m_RandomToppingTypeList.Count == 0)
            {
                m_ShopSlotList[6].SetEmptySlot();
                m_ShopSlotList[7].SetEmptySlot();
            }
            else
            {
                idx = Random.Range(0, m_RandomToppingTypeList.Count);
                m_ShopSlotList[6].SetShopSlot(m_RandomToppingTypeList[idx], GetIconSpriteFromString(m_RandomToppingTypeList[idx].ToString()));
                m_RandomToppingTypeList.RemoveAt(idx);
            
                idx = Random.Range(0, m_RandomToppingTypeList.Count);
                m_ShopSlotList[7].SetShopSlot(m_RandomToppingTypeList[idx], GetIconSpriteFromString(m_RandomToppingTypeList[idx].ToString()));
            }
            
            

            foreach (var var in m_ShopSlotList)
            {
                var.GetComponent<Button>().onClick.AddListener(()=>SlotClickAction(var));
                var.GetComponent<Button>().interactable = true;
                var.SoldOutObj.SetActive(false);
                SetSlotCanBuy(var);
            }
        }
    }


    public void SetSlotCanBuy(ShopSlot slot)
    {
        if (slot.PurchasePrice > PlayerDataManager.Instance.PlayerMoney || slot.IsEmptySlot) // or already max
        {
            slot.GetComponent<Button>().interactable = false;
        }
    }

    public void SetRandomList(int stage, int day)
    {
        m_RandomConeTypeList.Clear();
        m_RandomFlavorTypeList.Clear();
        m_RandomToppingTypeList.Clear();

        m_RandomConeTypeList = DataManager.Instance.StoryFlowData.StageDataDict[m_Stage].NightStage
            .Find(x => x.Day == DayCounter.Instance.Day).ConeTypes.ToList();
        m_RandomFlavorTypeList = DataManager.Instance.StoryFlowData.StageDataDict[m_Stage].NightStage
            .Find(x => x.Day == DayCounter.Instance.Day).FlavorTypes.ToList();
        m_RandomToppingTypeList = DataManager.Instance.StoryFlowData.StageDataDict[m_Stage].NightStage
            .Find(x => x.Day == DayCounter.Instance.Day).ToppingTypes.ToList();
    }

    public void SlotClickAction(ShopSlot slot)
    {
        m_SelectedSlot = slot;

        m_ShopPopup.gameObject.SetActive(true);
    }

    public void PopupOkAction()
    {
        //money check or Already Max Check
        
        //inventory?
        switch (m_SelectedSlot.ItemType)
        {
            case ItemType.Cone:
                PlayerDataManager.Instance.ConeInvenList.Find(x => x.ConeType == m_SelectedSlot.ConeEntity.ConeType).BuyFromShop();
                break;
            case ItemType.Flavor:
                PlayerDataManager.Instance.FlavorInvenList.Find(x=>x.FlavorType == m_SelectedSlot.FlavorEntity.FlavorType).BuyFromShop();
                break;
            case ItemType.Topping:
                PlayerDataManager.Instance.ToppingInvenList.Find(x=>x.ToppingType == m_SelectedSlot.ToppingEntity.ToppingType).BuyFromShop();
                break;
            
        }

        //set slot sold out
        m_SelectedSlot.GetComponent<Button>().interactable = false;
        m_SelectedSlot.IsSoldOut = true;
        m_SelectedSlot.SoldOutObj.SetActive(true);
        
        m_ShopPopup.gameObject.SetActive(false);
    }

    public string GetIconNameFromString(string str)
    {
        return "Icon_" + str;
    }

    public Sprite GetIconSpriteFromString(string objectName)
    {
        string iconName = GetIconNameFromString(objectName);
        
        return m_IconList.Find(x => x.name.Equals(iconName));
    }

    public void PopupCancelAction()
    {
        m_ShopPopup.gameObject.SetActive(false);
    }

}
