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
#nullable enable
    private int _max = 100;//TODO hard coded value
    private int _current;
    private int _index;
    private void Awake()
    {
        _index = transform.GetSiblingIndex();
        _current = _max;
        Reset();
    }
    public void Reset() 
    {
        RefreshSprite();
        enabled = true;
        _image.gameObject.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData) { }
    public void OnPointerDown(PointerEventData eventData)
    {
        SkillCheck.Instance.StartSkillCheck();
        SkillCheck.Instance.SnapPosition(transform);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        SkillCheck.Instance.StopSkillCheck();
        IcecreamScoop.Instance.Scoop(_index);
        _current -= SCOOP_PERFECT_AMOUNT;
        RefreshSprite();
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
            enabled = false;
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
