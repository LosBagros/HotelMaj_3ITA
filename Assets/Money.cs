using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField]
    private Button addMoneyButton;

    [SerializeField]
    private TMPro.TextMeshProUGUI moneyText;

    [SerializeField]
    private int money = 100;

    void Start()
    {
        addMoneyButton.onClick.AddListener(AddMoney);
        UpdateMoneyText();
    }

    void AddMoney()
    {
        money += 10;
        UpdateMoneyText();
    }

    void UpdateMoneyText()
    {
        moneyText.text = money + "$";
    }

    public bool CanAfford(int cost)
    {
        return money >= cost;
    }

    public void SpendMoney(int cost)
    {
        money -= cost;
        UpdateMoneyText();
    }

    public int GetMoney()
    {
        return money;
    }


}
