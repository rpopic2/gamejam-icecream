using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class DayStageEntity
{
    // 스테이지 값
    public long StageId;
    // 진행 날짜
    public long Day;
    // 등장할 손님
    public string CustomerFull;
    // 등장하는 맛
    public string FlavorFull;
    // 등장하는 토핑
    public string ToppingFull;
}

public class DayStage
{
    public long StageId { get; set; }
    public long Day { get; set; }
    public List<long> CustomerIds { get; set; }
    public List<FlavorType> FlavorTypes { get; set; }
    public List<ToppingType> ToppingTypes { get; set; }

    public DayStage(long stageId, long day, string customerFull, string flavorFull, string toppingFull)
    {
        StageId = stageId;
        Day = day;

        CustomerIds = new List<long>();
        if (!String.IsNullOrEmpty(customerFull))
        {
            customerFull.Split(';').ToList().ForEach(e => CustomerIds.Add(long.Parse(e)));
        }

        FlavorTypes = new List<FlavorType>();
        if (!String.IsNullOrEmpty(flavorFull))
        {
            flavorFull.Split(';').ToList().ForEach(e => FlavorTypes.Add((FlavorType)Enum.Parse(typeof(FlavorType), e)));
        }

        ToppingTypes = new List<ToppingType>();
        if (!String.IsNullOrEmpty(toppingFull))
        {
            toppingFull.Split(';').ToList().ForEach(e => ToppingTypes.Add((ToppingType)Enum.Parse(typeof(ToppingType), e)));
        }
    }
}