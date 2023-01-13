using TMPro;
using UnityEngine;

public class SoldItemTextObject : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _price;

    public void Init(string itemName, int price)
    {
        _itemName.text = itemName;
        _price.text = price.ToString();
    }
}
