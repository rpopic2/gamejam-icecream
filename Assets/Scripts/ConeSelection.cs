using UnityEngine;
using Rpopic.Window;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ConeSelection : MonoBehaviour
{
    private Button _buttons;
    protected int _index;
    [SerializeField] private ConeType m_ConeType;
    private void Awake()
    {
        _index = transform.GetSiblingIndex();
        _buttons = GetComponent<Button>();
        _buttons.onClick.AddListener(SelectCone);

    }

    protected virtual void SelectCone()
    {
        if (Game.IsDay && Game.s_instance.NowSelectItemType == ItemType.Cone && PlayerDataManager.Instance.GetItemNumberFromType(m_ConeType) != 0)
        {
            IcecreamBuilder.Instance.SetCone(_index, m_ConeType) ;
        }
        else
        {
            if (Game.IsDay) {
                AlertBox.Instance.AlertAsync("아이템이 없습니다!");
            }
        }
    }
}
