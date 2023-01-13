using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public static DayCounter Instance;
    private TMP_Text _dayText;
    private static int s_day = 0;
    
    private void Awake()
    {
        Instance = this;
        _dayText = GetComponentInChildren<TMP_Text>();
    }
    public void IncrementDay()
    {
        s_day += 1;
        _dayText.text = $"DAY {s_day}";
    }
}
