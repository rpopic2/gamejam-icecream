using Rpopic.Window;
using UnityEngine;

public class ToppingSelection : ConeSelection
{
    [Header("Topping")]
    [SerializeField] private ToppingType m_ToppingType;

    protected override void SelectCone()
    {
        if (Game.IsDay && PlayerDataManager.Instance.GetItemNumberFromType(m_ToppingType) == 0) {
                AlertBox.Instance.AlertAsync("아이템이 없습니다!");
        }
        if (Game.IsDay && Game.s_instance.NowSelectItemType == ItemType.Topping && PlayerDataManager.Instance.GetItemNumberFromType(m_ToppingType) != 0) // && PlayerDataManager.Instance.GetItemNumberFromType(m_ToppingType) != 0)
        {
            PreviewIcecream.Instance.SetTopping(_index, m_ToppingType);
        }
    }
}
