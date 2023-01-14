using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PreviewIcecream : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static PreviewIcecream Instance;
    [SerializeField] Image _previewImage;
    private void Awake()
    {
        Instance = this;
    }
    public void SetCone(int index)
    {
        //TODO implement this thang
        print(index);
        _previewImage.gameObject.SetActive(true);
    }
    public void SetFlavor(int index)
    {
        _previewImage.color = Color.red;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IcecreamScoop.Instance.Clear();
        SetFlavor(0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IcecreamScoop.Instance.Maximize();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IcecreamScoop.Instance.RestoreSize();
    }

    public void SetTopping(int index)
    {
        //TODO implement this
        print(index);
    }
}
