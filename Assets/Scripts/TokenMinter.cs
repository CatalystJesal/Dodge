using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enjin.SDK;
using Enjin.SDK.DataTypes;
using Enjin.SDK.Core;

public class TokenMinter : MonoBehaviour
{

    private GameStatus gameState;

    WalletManager walletManager;

    [SerializeField]
    private int mintPerScore = 5;

    //the id of the token we will mint
    private string dodgeCoinId = "1800000000000fa2";

    private bool isTokensMinted = false;


    // Start is called before the first frame update
    void Start()
    {
        walletManager = FindObjectOfType<WalletManager>();
        MintTokens();
    }

    void Update() {
        if(isTokensMinted){
            walletManager.SynchronizeWalletChanges();
            isTokensMinted = false;
        }
    }

    async private void MintTokens(){
        gameState = FindObjectOfType<GameStatus>();

        Identity adminIdentity = AccountManager.instance.adminIdentity;

        Wallet playerWallet  = walletManager.GetPlayerWallet();

        Debug.Log("Admin identity id: " + adminIdentity.id);

        Debug.Log("Player wallet address: " + playerWallet.ethAddress);

        string[] receivers = new string[] { playerWallet.ethAddress };

        int tokensToMint = gameState.GetScore() / mintPerScore;

        Debug.Log("Tokens to mint: " + tokensToMint);

        if(tokensToMint >= 1) {
            Debug.Log("Minting tokens: " + tokensToMint);
            Enjin.SDK.Core.Enjin.MintFungibleItem(adminIdentity.id, receivers, dodgeCoinId, tokensToMint, delegate(RequestEvent re) {
                Debug.Log("Tokens have been minted!");
                isTokensMinted = true;

            });
        }

    }
}
