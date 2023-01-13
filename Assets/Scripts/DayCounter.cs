using TMPro;
using UnityEngine;

public class DayCounter : MonoBehaviour
{
    public static DayCounter Instance;
    private TMP_Text _dayText;
    private static int s_month = 1;
    private static int s_day = 0;
    private static WeekDayName weekDay = WeekDayName.Sun;
    
    private void Awake()
    {
        Instance = this;
        _dayText = GetComponentInChildren<TMP_Text>();
        IncrementDay();
    }
    public void IncrementDay()
    {
        s_day += 1;
        if (weekDay == WeekDayName.Sun) weekDay = WeekDayName.Mon;
        else weekDay += 1;
        _dayText.text = $"{weekDay.ToString()} {s_month}. {s_day}";
    }
}
