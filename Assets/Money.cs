using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text userMoneyText;

    void Update()
    {
        userMoneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
