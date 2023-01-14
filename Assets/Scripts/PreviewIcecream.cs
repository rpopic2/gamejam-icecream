using System.Collections.Generic;
using System.Threading.Tasks;
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
            flavor;
        public List<int> topping => new List<int>();
    }
}

public class PreviewIcecream : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static PreviewIcecream Instance;
    [SerializeField] Image _previewImage;
    [SerializeField] Button _submitButton;
    [SerializeField] private UICustomer UICustomer;
    public static Player Player = new Player(); // 임시로 바로 할당
    private IcecreamData _icecream;
    public Task<bool> UserSubmit => _userSubmit;
    private TaskCompletionSource<bool> tcs;
    private Task<bool> _userSubmit;
    private void Awake()
    {
        Instance = this;
        _submitButton.onClick.AddListener(Submit);
    }
    public async void StartLoop()
    {
        do {
            Init();
            tcs = new();
            _userSubmit = tcs.Task;
            UICustomer.Instance.ReadyToCustomerUI(Player.Customer);
            await CustomerTweener.Instance.CustomerIn();
            Dialog.Instance.Print(Player.Order.OrderScriptParse());
            await _userSubmit;
            await Dialog.Instance.WaitDialogAsync();
            await CustomerTweener.Instance.CustomerOut();
        } while (Game.IsDay);
    }
    private void Init()
    {
        _icecream = default;
        _previewImage.gameObject.SetActive(false);
        _previewImage.color = Color.white;

        Player.SetCustomer();
        Player.SetOrder();
    }
    public void SetCone(int index)
    {
        //TODO implement this thang
        _icecream.cone = index + 1;
        _previewImage.gameObject.SetActive(true);
    }
    public void SetFlavor(int index)
    {
        _previewImage.color = Color.red;
        _icecream.flavor = index + 1;

        Debug.Log(_icecream.flavor);
    }
    public void SetTopping(int index)
    {
        //TODO implement this
        _icecream.topping.Add(index + 1);
    }
    public void Submit()
    {
        var (score, talk) = IcecreamJudge.Evaluate(_icecream, Player.Order);
        print($"you get {score} score");
        Dialog.Instance.Print(talk);
        MoneyBalance.Instance.Balance += score;
        tcs.SetResult(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IcecreamScoop.Instance.Clear();
        SetFlavor(IcecreamScoop.Instance.flavorIdx);
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
