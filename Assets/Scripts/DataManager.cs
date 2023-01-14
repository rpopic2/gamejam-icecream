using System.Threading.Tasks;
using UnityEngine;

public class DataManager : MonoSingleton<DataManager>
{
    [SerializeField] private InGameData _inGameData;
    [SerializeField] private StoryFlowData _storyFlowData;

    public InGameData InGameData => _inGameData;
    public StoryFlowData StoryFlowData => _storyFlowData;

    // 리소스 로드 전용
    public ResourceCustomer ResourceCustomer;

    private const int m_MaxNum = 10;
    public int MaxNum => m_MaxNum;

    private const int m_FlavorMaxNum = 100;
    public int FlavorMaxNum => m_FlavorMaxNum;
    
    private void Awake()
    {
        InGameData.LowDataLoad();
        StoryFlowData.LowDataLoad();

        InGameData.ProcessedDataLoad();
        StoryFlowData.ProcessedDataLoad();

        ResourceCustomer.LoadResources();
    }
}
