using Rpopic.Window;
using TMPro;
using UnityEngine;

public class ResultWindow : Window
{
    [SerializeField] private Transform _soldItemPrefab;
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private TMP_Text _sumText;

    protected override void Awake()
    {
        base.Awake();
        //TODO temp adding items
        for (int i = 0; i < 4; ++i)
        {
            var sold = Instantiate(_soldItemPrefab, _itemsParent)
                .GetComponent<SoldItemTextObject>();
            sold.Init("Chocolate Icecream", 20);
        }
        _sumText.text = (20 * 4).ToString();
    }
}
