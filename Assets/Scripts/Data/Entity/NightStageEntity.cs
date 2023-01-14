using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class NightStageEntity
{
    public long StageId;
    public long Day;

    public string ConePool;
    public string FlavorPool;
    public string ToppingPool;

    public long MoveCost;
    public long Honor;
}

public class NightStage
{
    public long StageId { get; set; }
    public long Day { get; set; }
    public long MoveCost { get; set; }
    public long Honor { get; set; }
    public List<ConeType> ConeTypes { get; set; } = new List<ConeType>();
    public List<FlavorType> FlavorTypes { get; set; } = new List<FlavorType>();
    public List<ToppingType> ToppingTypes { get; set; } = new List<ToppingType>();

    public NightStage(NightStageEntity data)
    {
        StageId = data.StageId;
        Day = data.Day;

        MoveCost = data.MoveCost;
        Honor = data.Honor;

        if (!String.IsNullOrEmpty(data.ConePool))
        {
            data.ConePool.Split(';').ToList().ForEach(e => ConeTypes.Add((ConeType)Enum.Parse(typeof(ConeType), e)));
        }

        if (!String.IsNullOrEmpty(data.FlavorPool))
        {
            data.FlavorPool.Split(';').ToList().ForEach(e => FlavorTypes.Add((FlavorType)Enum.Parse(typeof(FlavorType), e)));
        }

        if (!String.IsNullOrEmpty(data.ToppingPool))
        {
            data.ToppingPool.Split(';').ToList().ForEach(e => ToppingTypes.Add((ToppingType)Enum.Parse(typeof(ToppingType), e)));
        }
    }
}