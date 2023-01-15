using UnityEngine;
using Rpopic.Window;
using System.Threading.Tasks;
using System;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Sprite _dayBGSprite;
    [SerializeField] private Sprite _nightBGSprite;
    [SerializeField] private Image _bgImage;
    [SerializeField] private Image _talkBallonImage;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private float _dayTimeLimit;
    public static Game s_instance;
    private static Window s_resultWindow;
    private static Window s_shopWindow;
#nullable enable
    private static GameObjectDict<Window>? s_windows;
    public static  bool IsDay = true;
    private bool _isGameRunning = false;

    public ItemType NowSelectItemType = ItemType.Cone;
    
    private void Awake()
    {
        if (_isGameRunning) return;
        s_instance = this;
        if (s_windows is null) s_windows = new(_canvas);
        s_resultWindow = s_windows?["win_result"] ?? throw new Exception("cannot find result window");
        s_shopWindow = s_windows?["ShopUI"] ?? throw new Exception("cannot find result window");
        DontDestroyObject.LoadDontDestroy();
    }
    private void Start()
    {
        MenuBarCtl.Instance.EnableBar();
        if (_isGameRunning) return;
        _isGameRunning = true;
        Main();
    }
    private static async void Main()
    {
        while (true) 
        {
            await Day();
            await ShowResult();
            await ShopPhase();
        }
    }
    private static async Task Day()
    {
        s_instance._bgImage.sprite = s_instance._dayBGSprite;
        s_instance._talkBallonImage.gameObject.SetActive(true);
        PreviewIcecream.dayBalance = 0;
        IsDay = true;
        SoundManager.Instance.PlayBGM("BGM_DayTime");
        DayCounter.Instance.IncrementDay();
        PreviewIcecream.Instance.StartLoop();
        var _timer = Timer.Instance;
        _timer.SetTimer(s_instance._dayTimeLimit);
        await _timer.StartTimerAsync();
        await PreviewIcecream.Instance.UserSubmit;
        SoundManager.Instance.PlaySFX("SFX_TimeOver");
        IsDay = false;
    }
    private static async Task ShowResult()
    {
        await AlertBox.Instance.AlertAsync("End day");
        s_resultWindow.Open();
        await s_resultWindow.CloseAsync;
    }
    private static async Task ShopPhase()
    {
        s_instance._talkBallonImage.gameObject.SetActive(false);
        SoundManager.Instance.PlayBGM("BGM_NightTime");
        s_instance._bgImage.sprite = s_instance._nightBGSprite;
        s_shopWindow.Open();
        var shop = s_shopWindow.GetComponent<ShopUI>();
        shop.SetUISlideIn();
        shop.SetShopSlotList();
        await s_shopWindow.CloseAsync;
    }
}

