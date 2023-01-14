using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    public static GameObject Toolbar;
    public static bool IsLoaded { get; private set; }
    static DontDestroyObject() {
    }
    public static void LoadDontDestroy() {
        if (IsLoaded) return;
        IsLoaded = true;
        SceneLoader.LoadAdditive(SceneName.DontDestroy);
    }
    private DontDestroyObject _instance;
    public void Awake()
    {
        IsLoaded = true;
        if (_instance is null) _instance = this;
        else
        {
            Debug.LogWarning("Duplicate DontDestroyCanvas");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
