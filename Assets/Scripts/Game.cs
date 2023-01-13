using UnityEngine;
using Rpopic.Window;

public class Game : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private DayCounter _dayCounter;
    private void Awake()
    {
    }
    private void Start()
    {
        _timer.OnTimerEnd = () => NextDay();
        _timer.SetTimer(2f);
        _timer.StartTimer();
        
    }
    private void NextDay()
    {
        AlertBox.Instance.Alert("End day", OnAnswer);
        void OnAnswer(bool result) {
            if (result) SceneLoader.Load(Scene.Night);
        }
    }
}

public enum WeekDayName
{
    Mon, Tue, Wed, Thu, Fri, Sat, Sun
}
