using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enjin.SDK;
using Enjin.SDK.DataTypes;
using Enjin.SDK.Core;

public class StoreController : MonoBehaviour
{

    private string dodgeCoinId = "1800000000000fa2";

    private WalletManager walletManager;

    private bool isTradeCreated = false;

    private string tradeIdToComplete = "";

    private int skinOneRequiredBalance = 5;
    private int skinTwoRequiredBalance = 10;
    private int skinThreeRequiredBalance = 15;

    // Start is called before the first frame update
    void Start()
    {
        walletManager = FindObjectOfType<WalletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTradeCreated){
            Request completeTradeRequest = Enjin.SDK.Core.Enjin.CompleteTradeRequest(AccountManager.instance.adminIdentity.id, tradeIdToComplete,  delegate(RequestEvent re) {
            Debug.Log("COMPLETE TRADE Callback! "+re.model+" "+re.event_type+" "+re.contract+" "+re.data.param1);
            tradeIdToComplete = "";
            isTradeCreated = false;
        });

          Debug.Log("Complete trade callback. " + completeTradeRequest.state);
        }
    }

    async public void PurchasePlayerSkin1(){
        string adminEthAddress = AccountManager.instance.adminIdentity.wallet.ethAddress;

        string skinId = "";

        int playerIdentityId =  AccountManager.instance.player.identities[0].id;

        //condition here to check if player balance is >= 5, if so then send 5 tokens for the value of one skin token
        if(walletManager.GetCoinBalance() >= skinOneRequiredBalance){
            TokenValueInputData[] sendToken = new TokenValueInputData[] { new TokenValueInputData(dodgeCoinId,  null, skinOneRequiredBalance ) };
            TokenValueInputData[] recieveToken  = new TokenValueInputData[] { new TokenValueInputData(skinId, null, 1 ) };

            Request createTradeRequest = Enjin.SDK.Core.Enjin.CreateTradeRequest(playerIdentityId, sendToken, adminEthAddress, recieveToken, 
            delegate(RequestEvent re) {
          
             tradeIdToComplete = re.data.param1;
                Debug.Log("CREATE TRADE Callback! "+re.model+" "+re.event_type+
                    " "+re.contract+" "+tradeIdToComplete);
             isTradeCreated = true;

            }
            );

             Debug.Log("Create trade callback. " + createTradeRequest.state);

        }
    }

        async public void PurchasePlayerSkin2(){
        string adminEthAddress = AccountManager.instance.adminIdentity.wallet.ethAddress;

        string skinId = "";

        int playerIdentityId =  AccountManager.instance.player.identities[0].id;

        //condition here to check if player balance is >= 5, if so then send 5 tokens for the value of one skin token
        if(walletManager.GetCoinBalance() >= skinTwoRequiredBalance){
            TokenValueInputData[] sendToken = new TokenValueInputData[] { new TokenValueInputData(dodgeCoinId,  null, skinTwoRequiredBalance ) };
            TokenValueInputData[] recieveToken  = new TokenValueInputData[] { new TokenValueInputData(skinId, null, 1 ) };

            Request createTradeRequest = Enjin.SDK.Core.Enjin.CreateTradeRequest(playerIdentityId, sendToken, adminEthAddress, recieveToken, 
            delegate(RequestEvent re) {
          
             tradeIdToComplete = re.data.param1;
                Debug.Log("CREATE TRADE Callback! "+re.model+" "+re.event_type+
                    " "+re.contract+" "+tradeIdToComplete);
             isTradeCreated = true;

            }
            );

             Debug.Log("Create trade callback. " + createTradeRequest.state);

        }
    }

    
        async public void PurchasePlayerSkin3(){
        string adminEthAddress = AccountManager.instance.adminIdentity.wallet.ethAddress;

        string skinId = "";

        int playerIdentityId =  AccountManager.instance.player.identities[0].id;

        //condition here to check if player balance is >= 5, if so then send 5 tokens for the value of one skin token
        if(walletManager.GetCoinBalance() >= skinThreeRequiredBalance){
            TokenValueInputData[] sendToken = new TokenValueInputData[] { new TokenValueInputData(dodgeCoinId,  null, skinThreeRequiredBalance ) };
            TokenValueInputData[] recieveToken  = new TokenValueInputData[] { new TokenValueInputData(skinId, null, 1 ) };

            Request createTradeRequest = Enjin.SDK.Core.Enjin.CreateTradeRequest(playerIdentityId, sendToken, adminEthAddress, recieveToken, 
            delegate(RequestEvent re) {
          
             tradeIdToComplete = re.data.param1;
                Debug.Log("CREATE TRADE Callback! "+re.model+" "+re.event_type+
                    " "+re.contract+" "+tradeIdToComplete);
             isTradeCreated = true;

            }
            );

             Debug.Log("Create trade callback. " + createTradeRequest.state);

        }
    }
}
