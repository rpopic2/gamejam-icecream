using UnityEngine.SceneManagement;

public enum SceneName
{
    DontDestroy, Game, Night
}
public static class SceneLoader
{
    public static void Load(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    public static void LoadAdditive(SceneName scene)
    {
        SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Additive);
    }
}
