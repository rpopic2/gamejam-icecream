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
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
