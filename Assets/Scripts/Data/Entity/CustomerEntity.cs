using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class CustomerEntity
{
    // 손님 유일 값
    public long UniqueId;
    // 원하는 아이스크림
    public long IceCreamId;
    // 시나리오 스토리
    public long ScenarioId;
    // 손님 이름
    public string Name;
}

public class Customer
{
    public long UniqueId { get; private set; }
    public string Name { get; private set; }
    public long IceCreamId { get; private set; }
    public List<Scenario> ScenarioList { get; private set; }

    public Customer(long uniqueId, string name, long iceCreamId, IEnumerable<ScenarioEntity> scenarioEntity)
    {
        UniqueId = uniqueId;
        Name = name;
        IceCreamId = iceCreamId;

        ScenarioList = new List<Scenario>();
        if (scenarioEntity != null && scenarioEntity.Any())
        {
            foreach (var scenario in scenarioEntity)
            {
                ScenarioList.Add(
                    new Scenario(
                        scenario.GroupId,
                        scenario.Order,
                        scenario.NeedScore,
                        scenario.CommunicationType,
                        scenario.ScenarioScript));
            }
        }
    }
}
