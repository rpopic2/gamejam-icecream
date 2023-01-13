
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public long UniqueId { get; private set; }
    public string Name { get; private set; }

    // key : Scenario GroupId
    public Dictionary<long, List<Scenario>> ScenarioList { get; private set; }

    public Customer(long uniqueId, string name, IEnumerable<ScenarioEntity> scenarioEntity)
    {
        UniqueId = uniqueId;
        Name = name;

        ScenarioList = new Dictionary<long, List<Scenario>>();
        if (scenarioEntity != null && scenarioEntity.Any())
        {
            foreach (var scenario in scenarioEntity)
            {
                if (!ScenarioList.ContainsKey(scenario.GroupId))
                {
                    ScenarioList.Add(scenario.GroupId, new List<Scenario>());
                }

                ScenarioList[scenario.GroupId].Add(
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
