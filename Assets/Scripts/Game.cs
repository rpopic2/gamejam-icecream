using UnityEngine;
using Rpopic.Window;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    private void Start()
    {
        _timer.OnTimerEnd = () => NextDay();
        _timer.SetTimer(10f);
        _timer.StartTimer();
    }
    private void NextDay()
    {
        AlertBox.Instance.Alert("End day", OnAnswer);
        void OnAnswer(bool result) {
            if (result) SceneManager.LoadScene("Night");
        }
    }
}
