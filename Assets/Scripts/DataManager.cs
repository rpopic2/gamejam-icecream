using UnityEngine;

public class DataManager : MonoBehaviour
{
    // TODO
    // 데이터 로딩 UI Text 표기
    private void Start()
    {
        InGameData.Instance.LowDataLoad();

        InGameData.Instance.ProcessedDataLoad();
    }
}