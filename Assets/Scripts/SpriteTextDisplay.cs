using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteTextDisplay : MonoBehaviour
{

    private SpriteHandler spriteHandler;

    private Text activeSpriteText;
    // Start is called before the first frame update
    void Start()
    {
        spriteHandler = FindObjectOfType<SpriteHandler>();
        activeSpriteText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        activeSpriteText.text = "Current Sprite: " + spriteHandler.GetActiveSpriteName();
    }
}
