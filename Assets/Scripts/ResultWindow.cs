using Rpopic.Window;
using TMPro;
using UnityEngine;

public class ResultWindow : Window
{
    [SerializeField] private Transform _soldItemPrefab;
    [SerializeField] private Transform _itemsParent;
    [SerializeField] private TMP_Text _sumText;

    int yesterdayMoney = 0;
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
        onOpen += OnOpen;
        _sumText.text = PreviewIcecream.dayBalance.ToString();
    }
    void OnOpen() 
    {
        var money = PlayerDataManager.Instance.PlayerMoney ;
        _sumText.text = $"{money - yesterdayMoney}";
        yesterdayMoney = money;
    }
}
