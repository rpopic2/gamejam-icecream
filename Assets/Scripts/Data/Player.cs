
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public long Stage { get; set; }
    public long Day { get; set; }
    public long Gold { get; set; }


    // 지금 만들고 있는 아이스크림
    public IceCream IceCream { get; set; }
    // 지금 받은 손님
    public Customer Customer { get; set; }


    //public Scenario GetSceanrio(long order) => 
    //    Customer.ScenarioList.FirstOrDefault(e => e.Order == order);

    //public DayStage GetDayStage =>
    //    DataManager.Instance.StoryFlowData.GetDayStage(Stage, Day);

    //public IceCream GetAnswerIceCream =>
    //    DataManager.Instance.InGameData.GetIceCream(Customer.IceCreamId);

}