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
    [SerializeField] private List<Sprite> _coneSprites;
    [SerializeField] private List<Sprite> _iceSprites;
    [SerializeField] private List<Sprite> _iceCrapeSprites;
    [SerializeField] private List<Sprite> _toppingSprites;
    [SerializeField] private List<Transform> _toppingPrefabs;
    public static PreviewIcecream Instance;
    [SerializeField] Image _previewImage;
    [SerializeField] Image _iceImage;
    [SerializeField] Image _toppingImage;
    [SerializeField] Button _submitButton;
    [SerializeField] private UICustomer UICustomer;
    public static Player Player = new Player(); // ÀÓ½Ã·Î ¹Ù·Î ÇÒ´ç
    private IcecreamData _icecream;
    private TaskCompletionSource<bool> _tcs;
    public Task<bool> UserSubmit { get; private set; }
    [SerializeField] private GameObject _drumParent;
    public static GameObjectDict<FlavorSelection> _drums;
    private Transform _pLastTopping;
    private void Awake()
    {
        Instance = this;
        _submitButton.onClick.AddListener(Submit);
        _drums = new(_drumParent);
    }
    public async void StartLoop()
    {
        do {
            Init();
            _tcs = new();
            UserSubmit = _tcs.Task;
            UICustomer.Instance.ReadyToCustomerUI(Player.Customer);
            await CustomerTweener.Instance.CustomerIn();
            Dialog.Instance.Print(Player.Order.OrderScriptParse());
            await UserSubmit;
            await Dialog.Instance.WaitDialogAsync();
            await CustomerTweener.Instance.CustomerOut();
            foreach (var drum in _drums) {
                drum.AllowClick(true);
            }
        } while (Game.IsDay);
    }
    private void Init()
    {
        _icecream = default;
        _previewImage.gameObject.SetActive(false);
        _iceImage.gameObject.SetActive(false);
        if (_pLastTopping is not null)
        {
            Destroy(_pLastTopping);
            _pLastTopping = null;
        }

        Player.SetCustomer();
        Player.SetOrder();
        orig = _previewImage.transform.position;
    }
    Vector3 orig;
    public void SetCone(int index)
    {
        //TODO implement this thang
        _icecream.cone = index + 1;
        _previewImage.transform.position = orig;
        if (index == 1) {
            _previewImage.transform.Translate(Vector3.up * 50);
        }
        _previewImage.gameObject.SetActive(true);
        _previewImage.sprite = _coneSprites[index];
    }
    public void SetFlavor(int index)
    {
        _icecream.flavor = index + 1;
        _iceImage.gameObject.SetActive(true);
        if (_icecream.cone == 3) {
            _iceImage.sprite = _iceCrapeSprites[index];
        }
        else _iceImage.sprite = _iceSprites[index];
    }
    public void SetTopping(int index)
    {
        //TODO implement this
        _icecream.topping.Add(index + 1);
        //_toppingImage.sprite = _toppingSprites[index];
        _pLastTopping = Instantiate(_toppingPrefabs[index], transform);
    }
    public void Submit()
    {
        var (score, talk) = IcecreamJudge.Evaluate(_icecream, Player.Order);
        print($"you get {score} score");
        Dialog.Instance.Print(talk);
        MoneyBalance.Instance.Balance += score;
        _tcs.SetResult(true);
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
