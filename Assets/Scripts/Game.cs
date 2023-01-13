using UnityEngine;
using Rpopic.Window;

public class Game : MonoBehaviour
{
    [SerializeField] private DayCounter _dayCounter;
    private void Awake()
    {
        if (!DontDestroyObject.IsLoaded) SceneLoader.LoadAdditive(SceneName.DontDestroy);
    }
    private void Start()
    {
        DayCounter.Instance.IncrementDay();
        var _timer = Timer.Instance;
        _timer.OnTimerEnd = () => NextDay();
        _timer.SetTimer(2f);
        _timer.StartTimer();
        
    }
    private void NextDay()
    {
        AlertBox.Instance.Alert("End day", OnAnswer);
        void OnAnswer(bool result) {
            if (result) SceneLoader.Load(SceneName.Night);
        }
    }
}

public enum WeekDayName
{
    Mon, Tue, Wed, Thu, Fri, Sat, Sun
}
