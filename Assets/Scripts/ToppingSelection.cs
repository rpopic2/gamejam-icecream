using UnityEngine;

public class ToppingSelection : ConeSelection
{
    [Header("Topping")]
    [SerializeField] private ToppingType m_ToppingType;

    protected override void SelectCone()
    {
        if (Game.IsDay && Game.s_instance.NowSelectItemType == ItemType.Topping)
        {
            PreviewIcecream.Instance.SetTopping(_index, m_ToppingType);
        }
    }
}
