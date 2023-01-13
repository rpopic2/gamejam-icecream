using UnityEngine.SceneManagement;

public enum Scene
{
    Day, Night
}
public static class SceneLoader
{
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
