
using System.Collections.Generic;
using System;
using UnityEngine;

// Data : 엑셀에서 받아온 데이터
// EntityDict : 가공하지 않은 데이터
// DataDict : 사용 가능한 데이터
public class InGameData : DataBase 
{
    [SerializeField] private CustomerData CustomerData;
    [SerializeField] private ScenarioData ScenarioData;
    [SerializeField] private DayStageData DayStageData;
    [SerializeField] private IceCreamData IceCreamData;

    // Key : Customer UniqueId
    private Dictionary<long, CustomerEntity> CustomerEntityDict = new Dictionary<long, CustomerEntity>();

    // Key : Scenario GroupId
    private Dictionary<long, List<ScenarioEntity>> ScenarioEntityDict = new Dictionary<long, List<ScenarioEntity>>();

    // Key : IceCream UniqueId
    private Dictionary<long, IceCreamEntity> IceCreamEntityDict = new Dictionary<long, IceCreamEntity>();


    public Dictionary<long, Customer> CustomerDataDict = new Dictionary<long, Customer>();
    public Dictionary<long, IceCream> IceCreamDataDict = new Dictionary<long, IceCream>();



    public override void LowDataLoad()
    {
        CustomerEntityDict.Clear();

        foreach (var data in CustomerData.CustomerDatas)
        {
            if (!CustomerEntityDict.ContainsKey(data.UniqueId))
            {
                CustomerEntityDict.Add(data.UniqueId, data);
            }
            else
            {
                Console.WriteLine($"CustomerEntityDict Duplicate {data.UniqueId}");
            }
        }

        ScenarioEntityDict.Clear();

        foreach (var data in ScenarioData.ScenarioDatas)
        {
            if (!ScenarioEntityDict.ContainsKey(data.GroupId))
            {
                ScenarioEntityDict.Add(data.GroupId, new List<ScenarioEntity>() { data });
            }
            else
            {
                ScenarioEntityDict[data.GroupId].Add(data);
            }
        }

        IceCreamDataDict.Clear();

        foreach (var data in IceCreamData.IceCreamDatas)
        {
            if (!IceCreamDataDict.ContainsKey(data.UniqueId))
            {
                IceCreamDataDict.Add(data.UniqueId,
                    new IceCream(
                        data.UniqueId,
                        data.Name,
                        data.Price,
                        data.ConeType,
                        data.FlavorType1, data.FlavorType2, data.FlavorType3,
                        data.ToppingType1, data.ToppingType2, data.ToppingType3));
            }
            else
            {
                Console.WriteLine($"IceCreamDataDict Duplicate {data.UniqueId}");
            }
        }
    }

    public override void ProcessedDataLoad()
    {
        CustomerDataDict.Clear();

        foreach (var customerEntity in CustomerEntityDict)
        {
            if (!ScenarioEntityDict.TryGetValue(customerEntity.Key, out var scenarioList))
            {
                Console.WriteLine($"ScenarioEntityDict Not Contain Customer {customerEntity.Key}");
            }

            if (!CustomerDataDict.ContainsKey(customerEntity.Key))
            {
                CustomerDataDict.Add(customerEntity.Key, 
                    new Customer(
                        customerEntity.Value.UniqueId, 
                        customerEntity.Value.Name,
                        customerEntity.Value.IceCreamId,
                        scenarioList));
            }
            else
            {
                Console.WriteLine($"CustomerDataDict Duplicate {customerEntity.Key}");
            }
        }
    }
}