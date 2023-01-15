using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FlavorSelection : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler
{
    private const int SCOOP_PERFECT_AMOUNT = 10;
    private const int SCOOP_BAD_AMOUNT = 20;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Image _image;
    [SerializeField] private FlavorType m_flavorType;
#nullable enable
    private int _max = 100;//TODO hard coded value
    private int _current;
    private int _index;

    private bool m_IsSkillCheck = false;
    
    private void Awake()
    {
        _index = transform.GetSiblingIndex();
        _current = _max;
        Reset();
    }
    public void Reset() 
    {
        RefreshSprite();
        AllowClick(true);
        _image.gameObject.SetActive(true);
    }
    public void AllowClick(bool value) => enabled = value;
    public void OnPointerClick(PointerEventData eventData) { }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Game.IsDay && Game.s_instance.NowSelectItemType == ItemType.Flavor && PlayerDataManager.Instance.GetItemNumberFromType(m_flavorType) != 0 && !m_IsSkillCheck)
        {
            SkillCheck.Instance.StartSkillCheck();
            SkillCheck.Instance.SnapPosition(transform);
            m_IsSkillCheck = true;
        }
        else
        {
            IcecreamScoop.Instance.SetIcereamData(_index, m_flavorType);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (m_IsSkillCheck)
        {
            SkillCheck.Instance.StopSkillCheck();
            IcecreamScoop.Instance.Scoop(_index, m_flavorType);
            _current -= SCOOP_PERFECT_AMOUNT;
            RefreshSprite();
            foreach(var v in PreviewIcecream._drums) {
                v.AllowClick(false);
            }

            m_IsSkillCheck = false;
        }
    }
    private void RefreshSprite()
    {
        if (GetCurrentSprite is Sprite sprite)
        {
            _image.sprite = sprite;
        }
        else
        {
            _image.gameObject.SetActive(false);
            AllowClick(false);
        }
    }
    private Sprite? GetCurrentSprite => _current switch {
        >= 80 => _sprites[0],
        >= 50 => _sprites[1],
        >= 30 => _sprites[2],
        > 0 => _sprites[3],
        _ => null
    };
}
