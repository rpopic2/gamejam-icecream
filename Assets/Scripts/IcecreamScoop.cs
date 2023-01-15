using UnityEngine;

public class IcecreamScoop : MonoBehaviour
{
    public static IcecreamScoop Instance;

    public int flavorIdx;
    public FlavorType FlavorType;

    private void Awake()
    {
        Instance = this;
    }

    public void SetIcereamData(int _flavor, FlavorType flavor)
    {
        flavorIdx = _flavor;
        FlavorType = flavor;
    }
    
    public void Scoop(int _flavor, FlavorType flavor)
    {
        flavorIdx = _flavor;
        FlavorType = flavor;
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
