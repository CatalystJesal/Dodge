using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enjin.SDK;
using Enjin.SDK.DataTypes;
using Enjin.SDK.Core;

public class WalletManager : MonoBehaviour
{
    private Wallet playerWallet;

    private int coinBalance;

    // Start is called before the first frame update
    void Start()
    {
        SynchronizeWalletChanges();
    }


    async public void SynchronizeWalletChanges(){
        playerWallet = Enjin.SDK.Core.Enjin.GetWalletBalances(AccountManager.instance.player.identities[0].wallet.ethAddress);

        if(playerWallet.balances.Length > 0){
            Debug.Log("re-assigning coin balance");
            coinBalance = playerWallet.balances[0].value;
        }

    }


    public int GetCoinBalance(){
        return coinBalance;
    }

    public Wallet GetPlayerWallet(){
        return playerWallet;
    }
}
