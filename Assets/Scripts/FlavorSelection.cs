using UnityEngine;
using UnityEngine.EventSystems;

public class FlavorSelection : MonoBehaviour, IPointerClickHandler, IPointerUpHandler, IPointerDownHandler
{
    private int _index;
    private void Awake()
    {
        _index = transform.GetSiblingIndex();
    }
    public void OnPointerClick(PointerEventData eventData) { }
    public void OnPointerDown(PointerEventData eventData)
    {
#if UNITY_EDITOR
        Debug.Log($"select : {_index}");
#endif

        SkillCheck.Instance.StartSkillCheck();
        SkillCheck.Instance.SnapPosition(transform);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        SkillCheck.Instance.StopSkillCheck();
        IcecreamScoop.Instance.Scoop(_index);
    }
}
