using UnityEngine;
using Rpopic.Window;
using System.Threading.Tasks;
using System;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private float _dayTimeLimit;
    private static Game s_instance;
    private static Window s_resultWindow;
#nullable enable
    private static GameObjectDict<Window>? s_windows;
    public static volatile bool IsDay = true;
    private bool _isGameRunning = false;
    private void Awake()
    {
        if (_isGameRunning) return;
        s_instance = this;
        if (s_windows is null) s_windows = new(_canvas);
        s_resultWindow = s_windows?["win_result"] ?? throw new Exception("cannot find result window");
        if (!DontDestroyObject.IsLoaded) SceneLoader.LoadAdditive(SceneName.DontDestroy);
    }
    private void Start()
    {
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
            //TODO await ReadyUp();
        }
    }
    private static async Task Day()
    {
        IsDay = true;
        DayCounter.Instance.IncrementDay();
        PreviewIcecream.Instance.StartLoop();
        var _timer = Timer.Instance;
        _timer.SetTimer(s_instance._dayTimeLimit);
        await _timer.StartTimerAsync();
        IsDay = false;
        await PreviewIcecream.Instance.UserSubmit;
    }
    private static async Task ShowResult()
    {
        await AlertBox.Instance.AlertAsync("End day");
        s_resultWindow.Open();
        await s_resultWindow.WaitCloseAsync();
    }
}

