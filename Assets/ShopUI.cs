using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("ShopUI")]
    //temp
    [SerializeField] private List<ShopSlot> m_ShopSlotList;
    
    [SerializeField] private ShopPopup m_ShopPopup;
    
    private ShopSlot m_SelectedSlot;
    
    void Start()
    {
        m_ShopPopup.OKButton.onClick.AddListener(PopupOkAction);
        m_ShopPopup.CancelButton.onClick.AddListener(PopupCancelAction);
        SetShopSlotList();
    }

    public void SetShopSlotList()
    {
        /*
        foreach (var slot in m_ShopSlotList)
        {
            //temp
            slot.SetShopSlot();

            slot.gameObject.GetComponent<Button>().onClick.AddListener(() => SlotClickAction(slot));
        }
        */
    }

    public void SlotClickAction(ShopSlot slot)
    {
        m_SelectedSlot = slot;

        m_ShopPopup.gameObject.SetActive(true);
    }

    public void PopupOkAction()
    {
        //money check
        
        //inventory?

        //set slot sold out
        m_SelectedSlot.GetComponent<Button>().interactable = false;
        
        m_ShopPopup.gameObject.SetActive(false);
    }

    public void PopupCancelAction()
    {
        m_ShopPopup.gameObject.SetActive(false);
    }

}
