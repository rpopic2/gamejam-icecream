using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private InGameData _inGameData;
    [SerializeField] private StoryFlowData _storyFlowData;

    public InGameData InGameData => _inGameData;
    public StoryFlowData StoryFlowData => _storyFlowData;

    private void Start()
    {
        InGameData.LowDataLoad();
        StoryFlowData.LowDataLoad();

        InGameData.ProcessedDataLoad();
        StoryFlowData.ProcessedDataLoad();
    }
}