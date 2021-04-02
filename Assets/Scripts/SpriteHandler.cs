using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteHandler : MonoBehaviour
{



    [SerializeField]
    private int activeSkinIndex = 0;

    private string activeSpriteName = "Default";

    public Button defaultCatBtn;
    public Button pirateCatBtn;

    public Button blackCatBtn;

    public Button greenCatBtn;

    private WalletManager walletManager;

    void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        walletManager = FindObjectOfType<WalletManager>();
        ToggleAssetOwnership();
        // pirateCatBtn.interactable = true;
        // blackCatBtn.interactable = true;
        // greenCatBtn.interactable = true;
    }

    public void ToggleAssetOwnership()
    {
        if (walletManager.isAssetOwned(walletManager.GetPirateCatId()))
        {
            pirateCatBtn.interactable = true;
        }
        if (walletManager.isAssetOwned(walletManager.GetBlackCatId()))
        {
            blackCatBtn.interactable = true;
        }

        if (walletManager.isAssetOwned(walletManager.GetGreenCatId()))
        {
            greenCatBtn.interactable = true;
        }
    }

    public void useDefaultCatSkin()
    {
        activeSkinIndex = 0;
        activeSpriteName = "Default";
        // Debug.Log(activeSkinIndex);
    }

    public void usePirateCatSkin()
    {
        activeSkinIndex = 1;
        activeSpriteName = "Pirate Cat";
        // Debug.Log(activeSkinIndex);
    }

    public void useBlackCatSkin()
    {
        activeSkinIndex = 2;
        activeSpriteName = "Black Cat";
        // Debug.Log(activeSkinIndex);
    }

    public void useGreenCatSkin()
    {
        activeSkinIndex = 3;
        activeSpriteName = "Green Cat";
        // Debug.Log(activeSkinIndex);
    }

    public int GetActiveSkinIndex()
    {
        return activeSkinIndex;
    }

    public string GetActiveSpriteName()
    {
        return activeSpriteName;
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

}
