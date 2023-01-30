using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceText;
    [SerializeField] private int _startingMoney;
    public static MoneyBalance Instance;
    private int _balance;
    /// <summary>
    /// DO NOT USE THIS TO SET THE ACTUAL BALANCE, PlayerDataManager.Instance.PlayerBalance
    /// This only updates the UI
    /// </summary>
    public int Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            _balanceText.text = _balance.ToString();
        }
    }
    private void Awake()
    {
        Instance = this;
        Balance = _startingMoney;
        PlayerDataManager.Instance.OnPlayerMoneyChanged += (value) => Balance = value;
    }
}
