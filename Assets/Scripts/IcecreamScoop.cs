using UnityEngine;

public class IcecreamScoop : MonoBehaviour
{
    public static IcecreamScoop Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void Scoop()
    {
        gameObject.SetActive(true);
    }
    public void Clear()
    {
        gameObject.SetActive(false);

    }
    public void Maximize()
    {
        //TODO change sprite
        transform.localScale *= 4;
    }
    public void RestoreSize()
    {
        //TODO change sprite
        transform.localScale /= 4;
    }
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
