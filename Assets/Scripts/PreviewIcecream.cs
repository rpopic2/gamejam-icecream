using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using IcecreamData = Icecream.IcecreamData;

namespace Icecream
{
    public struct IcecreamData
    {
        //TODO this is a stub impl
        public
            int cone,
            flavor,
            topping;
    }
}

public class PreviewIcecream : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static PreviewIcecream Instance;
    [SerializeField] Image _previewImage;
    [SerializeField] Button _submitButton;
    private IcecreamData _icecream;
    private void Awake()
    {
        Instance = this;
        _submitButton.onClick.AddListener(Submit);
    }
    private void ClearImage()
    {
        //TODO clear image
    }
    public void SetCone(int index)
    {
        //TODO implement this thang
        _icecream.cone = index;
        _previewImage.gameObject.SetActive(true);
    }
    public void SetFlavor(int index)
    {
        _previewImage.color = Color.red;
        _icecream.flavor = index;
    }
    public void SetTopping(int index)
    {
        //TODO implement this
        _icecream.topping = index;
    }
    public void Submit()
    {
        var (score, talk) = IcecreamJudge.Evaluate(_icecream);
        print($"you get {score} score");
        Dialog.Instance.Talk(talk);
        MoneyBalance.Instance.Balance += score;
        ClearImage();
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
}
