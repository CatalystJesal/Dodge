using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Enjin.SDK;
using Enjin.SDK.DataTypes;
using Enjin.SDK.Core;



public class AccountManager : MonoBehaviour
{

    public static AccountManager instance;

    public User player = null;

    public Identity adminIdentity = null;

    private readonly string PLATFORM_URL = "https://kovan.cloud.enjin.io/";
    
    [SerializeField]
    private int APP_ID;

    [SerializeField]
    private string APP_SECRET;

    public GameObject username;

    public GameObject userId;

    public Text createAccInfoText;
    public Text loginAccInfoText;

    public int coinBalance;

    

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }

        createAccInfoText.text = "";
        loginAccInfoText.text = "";
        Enjin.SDK.Core.Enjin.StartPlatform(PLATFORM_URL, APP_ID, APP_SECRET);
        LoginAdmin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async public void LoginAdmin(){
        adminIdentity = Enjin.SDK.Core.Enjin.GetIdentity(10159);

    }

    async public void Login(){
        loginAccInfoText.text = "";
        int id = Int32.Parse(userId.GetComponent<InputField>().text);

        Debug.Log(id);

        try {
            player = Enjin.SDK.Core.Enjin.GetUser(id);

        } catch {

            loginAccInfoText.text = "The user id does not exist.";
            throw new Exception("There is no account tied to this user id");
        }

        if(player.identities.Length == 0) {
            loginAccInfoText.text = "The user id in invalid.";
            throw new Exception("There is no account tied to this user id");
        }

        Debug.Log(player.identities.Length);
        Debug.Log(player.identities[0].linkingCode);
        
        if(player.identities[0].linkingCode != ""){
            loginAccInfoText.text = "The user id has not been activated. Please link the account to your wallet address with Linking Code " + player.identities[0].linkingCode +".";
        } else {
             AuthPlayer(player.name);
        }
  

       
    }


    async public void CreatePlayer(){

        createAccInfoText.text = "";
        string name = username.GetComponent<InputField>().text;

        try {
        player =  Enjin.SDK.Core.Enjin.CreatePlayer(name);

        Debug.Log("The new User ID: " + player.id);
        Debug.Log("The new username: " + player.name);


        } catch {

            throw new Exception("User already exists, please try a different username");
        }

        createAccInfoText.text = "Account Created! Your Login ID is " + player.id +". " + "Use linking code " + player.identities[0].linkingCode + " to link your wallet address to this id. If you forget your User ID, please contact the game creator.";

    }

    
     async public void AuthPlayer(string name)
    {
        string accessToken = Enjin.SDK.Core.Enjin.AuthPlayer(name);

        Debug.Log(accessToken);


        GoToGame();
    }

    
    private void GoToGame(){
        SceneManager.LoadScene("GameScene");
    }
}
