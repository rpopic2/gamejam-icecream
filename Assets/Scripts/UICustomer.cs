using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UICustomer : MonoBehaviour
{
    public static UICustomer Instance;

    [SerializeField] private Image HairImage;
    [SerializeField] private Image SkinImage;
    [SerializeField] private Image ClothesImage;
    [SerializeField] private Image FaceImage;

    private void Awake()
    {
        Instance = this;
    }

    public void ReadyToCustomerUI(Customer customer)
    {
        var sprites = DataManager.Instance.ResourceCustomer.Sprites;

        if (sprites.TryGetValue(customer.Hair.Item2, out var hairList))
        {
            HairImage.sprite = hairList.FirstOrDefault(e => e.Item1 == customer.Hair.Item1).Item2;
        }

        if (sprites.TryGetValue(customer.Skin.Item2, out var skinList))
        {
            SkinImage.sprite = skinList.FirstOrDefault(e => e.Item1 == customer.Skin.Item1).Item2;
        }

        if (sprites.TryGetValue(customer.Clothes.Item2, out var clothesList))
        {
            ClothesImage.sprite = clothesList.FirstOrDefault(e => e.Item1 == customer.Clothes.Item1).Item2;
        }

        if (sprites.TryGetValue(customer.Face.Item2, out var faceList))
        {
            FaceImage.sprite = faceList.FirstOrDefault(e => e.Item1 == customer.Face.Item1).Item2;
        }
    }
}
