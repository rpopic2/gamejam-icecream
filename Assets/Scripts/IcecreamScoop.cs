using UnityEngine;

public class IcecreamScoop : MonoBehaviour
{
    public static IcecreamScoop Instance;

    public int flavorIdx;

    private void Awake()
    {
        Instance = this;
    }
    public void Scoop(int _flavor)
    {
        flavorIdx = _flavor;
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
