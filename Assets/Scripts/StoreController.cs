using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enjin.SDK;
using Enjin.SDK.DataTypes;
using Enjin.SDK.Core;

public class StoreController : MonoBehaviour
{
    private WalletManager walletManager;

    private string tradeIdToComplete = null;

    private int pirateCatCost = 5;
    private int blackCatCost = 10;
    private int greenCatCost = 15;

    public Button pirateCatBtn;
    public Button blackCatBtn;
    public Button greenCatBtn;

    private Identity adminIdentity;

    // Start is called before the first frame update
    void Start()
    {
        walletManager = FindObjectOfType<WalletManager>();
        adminIdentity = AccountManager.instance.adminIdentity;
        InitializeStore();


    }

    public void InitializeStore()
    {
        if (walletManager.GetCoinBalance() > pirateCatCost && !pirateCatBtn.interactable)
        {
            Debug.Log("Enable pirate cat: " + walletManager.GetCoinBalance() + " and cost is " + pirateCatCost);
            pirateCatBtn.interactable = true;
        }

        if (walletManager.GetCoinBalance() > blackCatCost && !blackCatBtn.interactable)
        {
            Debug.Log("Enable black cat: " + walletManager.GetCoinBalance() + " and cost is " + blackCatCost);
            blackCatBtn.interactable = true;
        }

        if (walletManager.GetCoinBalance() > greenCatCost && !greenCatBtn.interactable)
        {
            Debug.Log("Enable green cat: " + walletManager.GetCoinBalance() + " and cost is " + greenCatCost);
            greenCatBtn.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tradeIdToComplete != null)
        {
            //  Debug.Log("TradeIdToComplete: " + tradeIdToComplete);
            // Debug.Log("Admin id: " + adminIdentity.id);
            Debug.Log("App Id in Complete Trade: " + Enjin.SDK.Core.Enjin.AppID);

            Request completeTradeRequest = Enjin.SDK.Core.Enjin.CompleteTradeRequest(10159, tradeIdToComplete, delegate (RequestEvent re)
            {
                Debug.Log("COMPLETE TRADE Callback! " + re.model + " " + re.event_type + " " + re.contract + " " + re.data.param1);

                walletManager.SynchronizeWalletChanges();
                InitializeStore();

            });

            Debug.Log("Complete trade callback. " + completeTradeRequest.state);
            tradeIdToComplete = null;


        }
    }

    async public void PurchasePirateCat()
    {

        pirateCatBtn.interactable = false;
        blackCatBtn.interactable = false;
        greenCatBtn.interactable = false;

        string adminEthAddress = adminIdentity.wallet.ethAddress;

        int playerIdentityId = AccountManager.instance.player.identities[0].id;

        Debug.Log("Player identity: " + playerIdentityId);
        Debug.Log("Dodge Coin ID: " + walletManager.GetDodgeCoinId());
        Debug.Log("Pirate ID: " + walletManager.GetPirateCatId());

        Debug.Log("Admin ETH address: " + adminEthAddress);


        TokenValueInputData[] sendToken = new TokenValueInputData[] { new TokenValueInputData("1800000000000fa2", null, 1) };
        TokenValueInputData[] recieveToken = new TokenValueInputData[] { new TokenValueInputData("1800000000000fb5", null, 1) };

        Enjin.SDK.Core.Enjin.IsDebugLogActive = true;

        Request createTradeRequest = Enjin.SDK.Core.Enjin.CreateTradeRequest(10160, sendToken, "0xEEBD38e685673C3a5507972d2c3B2D22A728662D", recieveToken,
        delegate (RequestEvent re)
        {
            string tradeId = re.data.param1;

            Debug.Log("CREATE TRADE Callback! " + re.model + " " + re.event_type +
                " " + re.contract + " " + tradeIdToComplete);

            Debug.Log("App Id in Complete Trade: " + Enjin.SDK.Core.Enjin.AppID);

            tradeIdToComplete = tradeId;
        }
        );

        Debug.Log("Create trade callback. " + createTradeRequest.state);

    }

    async public void PurchaseBlackCat()
    {

        // pirateCatBtn.interactable = false;
        // blackCatBtn.interactable = false;
        // greenCatBtn.interactable = false;

        string adminEthAddress = adminIdentity.wallet.ethAddress;

        int playerIdentityId = AccountManager.instance.player.identities[0].id;

        TokenValueInputData[] sendToken = new TokenValueInputData[] { new TokenValueInputData(walletManager.GetDodgeCoinId(), null, blackCatCost) };
        TokenValueInputData[] recieveToken = new TokenValueInputData[] { new TokenValueInputData(walletManager.GetBlackCatId(), null, 1) };

        Request createTradeRequest = Enjin.SDK.Core.Enjin.CreateTradeRequest(playerIdentityId, sendToken, adminEthAddress, recieveToken,
        delegate (RequestEvent re)
        {

            tradeIdToComplete = re.data.param1;
            Debug.Log("CREATE TRADE Callback! " + re.model + " " + re.event_type +
                " " + re.contract + " " + tradeIdToComplete);

        }
        );

        Debug.Log("Create trade callback. " + createTradeRequest.state);

    }


    async public void PurchaseGreenCat()
    {
        string adminEthAddress = adminIdentity.wallet.ethAddress;

        int playerIdentityId = AccountManager.instance.player.identities[0].id;

        TokenValueInputData[] sendToken = new TokenValueInputData[] { new TokenValueInputData(walletManager.GetDodgeCoinId(), null, greenCatCost) };
        TokenValueInputData[] recieveToken = new TokenValueInputData[] { new TokenValueInputData(walletManager.GetGreenCatId(), null, 1) };

        Request createTradeRequest = Enjin.SDK.Core.Enjin.CreateTradeRequest(playerIdentityId, sendToken, adminEthAddress, recieveToken,
        delegate (RequestEvent re)
        {

            tradeIdToComplete = re.data.param1;
            Debug.Log("CREATE TRADE Callback! " + re.model + " " + re.event_type +
                " " + re.contract + " " + tradeIdToComplete);

            pirateCatBtn.interactable = false;
            blackCatBtn.interactable = false;
            greenCatBtn.interactable = false;

        }
        );

        Debug.Log("Create trade callback. " + createTradeRequest.state);
    }


    public int GetPirateCatCost()
    {
        return pirateCatCost;
    }

    public int GetBlackCatCost()
    {
        return blackCatCost;
    }

    public int GetGreenCatCost()
    {
        return greenCatCost;
    }
}
