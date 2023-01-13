using UnityEngine;
using Rpopic.Window;

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
    private static void Main()
    {
        Day();
        //TODO ReadyUp();
    }
    //TODO make async await
    private static void Day()
    {
        DayCounter.Instance.IncrementDay();
        var _timer = Timer.Instance;
        _timer.OnTimerEnd = () => ShowResult();
        _timer.SetTimer(2f);
        _timer.StartTimer();
    }
    private static void ShowResult()
    {
        AlertBox.Instance.Alert("End day", OnAnswer);
        void OnAnswer(bool _) {
            _windows?["win_result"].Open();
        }
    }
}

