using UnityEngine;

public class MenuBarCtl : MonoBehaviour
{
    public static MenuBarCtl Instance;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    public void EnableBar()
    {
        gameObject.SetActive(true);
    }
}
