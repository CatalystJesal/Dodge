using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private float moveInputX;
    private float leftClick;
    private Rigidbody2D rb;

    private float screenWidth;

    private float initialMousePosX;

    private bool isGameOver;

    private MenuLoader menuLoader;

    private SpriteHandler spriteHandler;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite[] playSkins;

    [SerializeField]
    private Sprite[] deathSkins;

    // Start is called before the first frame update
    void Start()
    {
        menuLoader = FindObjectOfType<MenuLoader>();
        spriteHandler = FindObjectOfType<SpriteHandler>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //need to check which skin the player picked on menu screen
        //create a class that manages sprites (SpriteManager), make a static class object internally (see AccountManager as example), then use this to determine what the player sprite should be upon start 
        //OR just use WalletManager to manage checks for wallet balance specific to the skin token id
        spriteRenderer.sprite = playSkins[spriteHandler.GetActiveSkinIndex()];

        screenWidth = Screen.width;
    }

    void FixedUpdate()
    {
        isGameOver = FindObjectOfType<GameStatus>().IsGameOver();

        if (!isGameOver)
        {
            MovementType2();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            leftClick = Input.GetAxis("Fire1");
            if (Input.GetMouseButtonDown(0) && leftClick > 0f)
            {
                initialMousePosX = Input.mousePosition.x;
            }
        }
    }


    void MovementType2()
    {

        if (leftClick > 0f && initialMousePosX > screenWidth / 2)
        {
            rb.velocity = new Vector2(leftClick * moveSpeed, rb.velocity.y);
        }
        else if (leftClick > 0f && initialMousePosX < screenWidth / 2)
        {
            rb.velocity = new Vector2(leftClick * -moveSpeed, rb.velocity.y);
        }
        else if (leftClick <= 0f)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Cactus"))
        {
            //create a class that manages sprites (SpriteManager), make a static class object internally (see AccountManager as example), then use this to determine what the player death sprite should be upon game over
            spriteRenderer.sprite = deathSkins[spriteHandler.GetActiveSkinIndex()];
            rb.velocity = new Vector2(0, 0);
            FindObjectOfType<GameStatus>().SetGameOver(true);
            menuLoader.LoadGameOver();
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            FindObjectOfType<GameStatus>().AddToScore();
            Destroy(other.gameObject);
        }
    }
}
