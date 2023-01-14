
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/// <summary>
/// 전반적인 이야기 흐름에 대한 데이터들
/// 낮 스테이지, 밤 스테이지
/// </summary>
public class StoryFlowData : DataBase
{
    [SerializeField] private ChapterData ChapterData;
    [SerializeField] private DayStageData DayStageData;
    [SerializeField] private NightStageData NightStageData;

    // Key : StageId
    private List<Chapter> ChapterList = new List<Chapter>();
    private Dictionary<long, List<DayStage>> DayStageDataDict = new Dictionary<long, List<DayStage>>();
    private Dictionary<long, List<NightStage>> NightStageDataDict = new Dictionary<long, List<NightStage>>();

    public Dictionary<long, Stage> StageDataDict = new Dictionary<long, Stage>();


    public override void LowDataLoad()
    {
        ChapterList.Clear();

        foreach (var data in ChapterData.ChapterDatas)
        {
            ChapterList.Add(new Chapter(data));
        }

        DayStageDataDict.Clear();

        foreach (var data in DayStageData.DayStageDatas)
        {
            var dayStage = new DayStage(data);

            if (!DayStageDataDict.ContainsKey(data.StageId))
            {
                DayStageDataDict.Add(data.StageId, new List<DayStage>() { dayStage });
            }
            else
            {
                DayStageDataDict[data.StageId].Add(dayStage);
            }
        }

        NightStageDataDict.Clear();

        foreach (var data in NightStageData.NightStageDatas)
        {
            var nightStage = new NightStage(data);

            if (!NightStageDataDict.ContainsKey(data.StageId))
            {
                NightStageDataDict.Add(data.StageId, new List<NightStage>() { nightStage });
            }
            else
            {
                NightStageDataDict[data.StageId].Add(nightStage);
            }
        }
    }

    public override void ProcessedDataLoad()
    {
        StageDataDict.Clear();

        foreach (var chapter in ChapterList)
        {
            var dayStage = DayStageDataDict.GetValueOrDefault(chapter.StageId);
            var nightStage = NightStageDataDict.GetValueOrDefault(chapter.StageId);

            StageDataDict.Add(chapter.StageId, new Stage { 
                StageId = chapter.StageId,
                DayStage = dayStage,
                NightStage = nightStage,
            });
        }

        Debug.Log("StageDataLoad Done");
    }

    public DayStage GetDayStage(long stageId, long day)
    {
        DayStageDataDict.TryGetValue(stageId, out var dayStages);

        return dayStages?.FirstOrDefault(e => e.Day == day);
    }

    public NightStage GetNightStage(long stageId, long day)
    {
        NightStageDataDict.TryGetValue(stageId, out var nightStages);

        return nightStages?.FirstOrDefault(e => e.Day == day);
    }

    public List<ConeType> GetAvailableConeTypes(long stageId, long day)
    {
        DayStageDataDict.TryGetValue(stageId, out var dayStages);

        return dayStages?.FirstOrDefault(e => e.Day == day).ConeTypes;
    }
}