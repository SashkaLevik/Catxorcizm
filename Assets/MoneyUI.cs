using CodeBase.Player;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private PlayerMoney _playerMoney;

    private void Awake()
    {
        _money.text = _playerMoney.CurrentMoneyLevel.ToString();
    }

    private void OnEnable()
    {
        _playerMoney.CurrentSoulChanged += OnChangeMoney;
    }

    private void OnDisable()
    {
        _playerMoney.CurrentSoulChanged -= OnChangeMoney;
    }

    private void OnChangeMoney(int arg0)
    {
        _money.text = _playerMoney.CurrentMoneyLevel.ToString();
    }
}
