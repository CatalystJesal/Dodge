using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceTextDisplay : MonoBehaviour
{

    private Text balanceText;

    private WalletManager walletManager;

    // Start is called before the first frame update
    void Start()
    {
        balanceText = GetComponent<Text>();
        walletManager =  FindObjectOfType<WalletManager>();
    }

    // Update is called once per frame
    void Update()
    {   

        balanceText.text = "Balance: " + walletManager.GetCoinBalance();
    }
}
