using System.Threading.Tasks;

public class Timer : FillTweener
{
    public static Timer Instance;
#nullable enable
    private Task? _timerTask;
    protected override void Awake()
    {
        Instance = this;
    }
    public void SetTimer(float time)
    {
        _time = time;
    }
    public async Task StartTimerAsync()
    {
        ResetTween();
        StartTween(1);
        var _timeInMilisecond = (int)(_time * 1000);
        await Task.Delay(_timeInMilisecond);
    }
}
