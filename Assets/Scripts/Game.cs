using UnityEngine;
using Rpopic.Window;
using System.Threading.Tasks;
using System;

public class Game : MonoBehaviour
{
    private bool _isGameRunning = false;
    [SerializeField] private GameObject _canvas;
#nullable enable
    private static GameObjectDict<Window>? _windows = null;
    private void Awake()
    {
        if (_isGameRunning) return;
        if (_windows is null) _windows = new(_canvas);
        if (!DontDestroyObject.IsLoaded) SceneLoader.LoadAdditive(SceneName.DontDestroy);
    }
    private void Start()
    {
        if (_isGameRunning) return;
        _isGameRunning = true;
        Main();
    }
    private async static void Main()
    {
        while (true) 
        {
            await Day();
            await ShowResult();
            //TODO await ReadyUp();
        }
    }
    //TODO make async await
    private async static Task Day()
    {
        DayCounter.Instance.IncrementDay();
        var _timer = Timer.Instance;
        _timer.SetTimer(2f);
        await _timer.StartTimer();
    }
    private async static Task ShowResult()
    {
        await AlertBox.Instance.AlertAsync("End day");
        var resultWindow = _windows?["win_result"] ?? throw new Exception("cannot find result window");
        resultWindow.Open();
        await resultWindow.AwaitClose();
    }
}

