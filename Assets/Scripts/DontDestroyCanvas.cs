using UnityEngine;

public class DontDestroyCanvas : MonoBehaviour
{
    public static DontDestroyCanvas Instance;
    public void Awake()
    {
        if (Instance is null) Instance = this;
        else
        {
            Debug.LogWarning("Duplicate DontDestroyCanvas");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
