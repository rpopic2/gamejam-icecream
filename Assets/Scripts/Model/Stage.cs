using System.Collections.Generic;

public class Stage
{
    public long StageId { get; set; }
    public List<DayStage> DayStage { get; set; }
    public List<NightStage> NightStage { get; set; }

}