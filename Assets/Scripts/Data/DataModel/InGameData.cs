
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

// Data : 엑셀에서 받아온 데이터
// EntityDict : 가공하지 않은 데이터
// DataDict : 사용 가능한 데이터
public class InGameData : DataBase 
{
    [SerializeField] private CustomerData CustomerData;
    // Key : Customer UniqueId
    private Dictionary<long, CustomerEntity> CustomerEntityDict = new Dictionary<long, CustomerEntity>();
    public Dictionary<long, Customer> CustomerDataDict = new Dictionary<long, Customer>();

    [SerializeField] private ScenarioData ScenarioData;
    // Key : CustomerId
    private Dictionary<long, List<ScenarioEntity>> ScenarioEntityDict = new Dictionary<long, List<ScenarioEntity>>();


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
            if (!ScenarioEntityDict.ContainsKey(data.CustomerId))
            {
                ScenarioEntityDict.Add(data.CustomerId, new List<ScenarioEntity>() { data });
            }
            else
            {
                ScenarioEntityDict[data.CustomerId].Add(data);
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
                        scenarioList));
            }
            else
            {
                Console.WriteLine($"CustomerDataDict Duplicate {customerEntity.Key}");
            }
        }
    }
}