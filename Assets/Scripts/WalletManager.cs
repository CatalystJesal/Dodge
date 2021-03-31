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

    private string dodgeCoinId = "1800000000000fa2";

    private string pirateCatId = "1800000000000fae";
    private string blackCatId = "1800000000000faf";
    private string greenCatId = "1800000000000fb0";

    // Start is called before the first frame update
    void Start()
    {
        SynchronizeWalletChanges();
    }


    async public void SynchronizeWalletChanges(){
        playerWallet = Enjin.SDK.Core.Enjin.GetWalletBalances(AccountManager.instance.player.identities[0].wallet.ethAddress);

        SetCoinBalance(playerWallet);

    }

    public Wallet GetPlayerWallet(){
        return playerWallet;
    }

    public string GetDodgeCoinId(){
        return dodgeCoinId;
    }

    public string GetPirateCatId(){
        return pirateCatId;
    }

    public string GetBlackCatId(){
        return blackCatId;
    }

    public string GetGreenCatId(){
        return greenCatId;
    }

    public int GetCoinBalance(){
        return coinBalance;
    }

    public void SetCoinBalance(Wallet wallet){
        for(int i = 0; i< wallet.balances.Length; i++){
            if(wallet.balances[i].id == dodgeCoinId) {
                Debug.Log("tokenId: " + wallet.balances[i].id);
                Debug.Log("value: " + wallet.balances[i].value);
                coinBalance =  wallet.balances[i].value;
            }
        }
    }

    //use this function in the Main Menu to enable/disable buttons for different skins and activate buttons
    public bool isAssetOwned(string tokenId){
        for(int i = 0; i< playerWallet.balances.Length; i++){
            if(playerWallet.balances[i].id == tokenId) {
                return true;
            }
        }

        return false;
    }
}
