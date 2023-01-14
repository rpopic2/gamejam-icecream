using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("ShopUI")]
    //temp
    [SerializeField] private List<ShopSlot> m_ShopSlotList;
    
    [SerializeField] private ShopPopup m_ShopPopup;
    
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

    public void SetShopSlotList()
    {
        if (m_ShopSlotList.Count == 8)
        {
            SetRandomList(m_Stage, DayCounter.Instance.Day);
            int idx;
            // 1 ~ 8 번 슬롯
            // 1 ~ 3번 : 기본맛 3가지 고정
            m_ShopSlotList[0].SetShopSlot(FlavorType.Strawberry);
            m_ShopSlotList[1].SetShopSlot(FlavorType.Chocolate);
            m_ShopSlotList[2].SetShopSlot(FlavorType.Vanilla);

            // 4번 : 콘슬롯
            idx = Random.Range(0, m_RandomConeTypeList.Count);
            m_ShopSlotList[3].SetShopSlot(m_RandomConeTypeList[idx]);

            // 5 ~ 6번 : 추가맛 3가지중 2가지
            idx = Random.Range(0, m_RandomFlavorTypeList.Count);
            m_ShopSlotList[4].SetShopSlot(m_RandomFlavorTypeList[idx]);
            m_RandomFlavorTypeList.RemoveAt(idx);
            
            idx = Random.Range(0, m_RandomFlavorTypeList.Count);
            m_ShopSlotList[5].SetShopSlot(m_RandomFlavorTypeList[idx]);
            
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
                m_ShopSlotList[6].SetShopSlot(m_RandomToppingTypeList[idx]);
                m_RandomToppingTypeList.RemoveAt(idx);
            
                idx = Random.Range(0, m_RandomToppingTypeList.Count);
                m_ShopSlotList[7].SetShopSlot(m_RandomToppingTypeList[idx]);
            }
            
            

            foreach (var var in m_ShopSlotList)
            {
                var.GetComponent<Button>().onClick.AddListener(()=>SlotClickAction(var));
                var.GetComponent<Button>().interactable = true;
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
        
        m_ShopPopup.gameObject.SetActive(false);
    }

    public void PopupCancelAction()
    {
        m_ShopPopup.gameObject.SetActive(false);
    }

}
