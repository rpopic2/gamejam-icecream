
using System.Linq;
using System.Collections.Generic;

public class Player
{
    public long Stage { get; set; }
    public long Day { get; set; }
    public long Gold { get; set; }


    // 지금 만들고 있는 아이스크림
    public IceCream IceCream { get; set; }
    // 지금 받은 손님
    public Customer Customer { get; set; }
    // 현재 주문 요청서
    public Order Order { get; set; }

    public DayStage GetDayStage =>
        DataManager.Instance.StoryFlowData.GetDayStage(Stage, Day);

    public NightStage GetNightStage =>
        DataManager.Instance.StoryFlowData.GetNightStage(Stage, Day);

    public List<ConeType> GetAvailableConeTypes =>
        DataManager.Instance.StoryFlowData.GetAvailableConeTypes(Stage, Day);
}