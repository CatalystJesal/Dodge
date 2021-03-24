using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Enjin.SDK;
using Enjin.SDK.DataTypes;
using Enjin.SDK.Core;



public class AccountManager : MonoBehaviour
{

    public static AccountManager instance;

    public Identity userIdentity = null;
    public Identity adminIdentity = null;

    private readonly string PLATFORM_URL = "https://kovan.cloud.enjin.io/";
    
    [SerializeField]
    private int APP_ID;
    [SerializeField]
    private string APP_SECRET;

    public GameObject username;

    public int coinBalance;

    

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
            instance = this;
        }

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
        string name = username.GetComponent<InputField>().text;

        userIdentity = Enjin.SDK.Core.Enjin.GetIdentity(10160);

        // Debug.Log(userIdentity.id);
        // Debug.Log(userIdentity.wallet.ethAddress);
        // Debug.Log(userIdentity.user.id);

        // User player = Enjin.SDK.Core.Enjin.GetUser(name);

        // Debug.Log("player id: " + player.id);
        // Debug.Log("player name: " + player.name);

        // User user = Enjin.SDK.Core.Enjin.GetUser(19781);

        User user2 = Enjin.SDK.Core.Enjin.GetUser(name);

        Debug.Log("user id: " + user2.id);
        Debug.Log("user name: " + user2.name);

        User user = Enjin.SDK.Core.Enjin.GetUser(19781);

        Debug.Log("user length : " + user2.identities.Length);

        for(int i = 0; i < user.identities.Length; i++ ){
            Debug.Log("Identity id: " + user.identities[i].id);
            Debug.Log("App id: " + user.identities[i].app.id);
            Debug.Log("wallet address: " + user.identities[i].wallet.ethAddress);
            Debug.Log("User name: " + user.name);
        }



        // AuthPlayer(name);
    }


    async public void CreatePlayer(){
        string name = username.GetComponent<InputField>().text;

 
        try {
        User newUser =  Enjin.SDK.Core.Enjin.CreatePlayer(name);

        Debug.Log("The new User ID: " + newUser.id);
        Debug.Log("The new username: " + newUser.name);

        } catch {
            Debug.Log("User already exists, please try a different username");
        }

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
