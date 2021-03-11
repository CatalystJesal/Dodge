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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenWidth = Screen.width;
    }

    void FixedUpdate() {
        isGameOver = FindObjectOfType<GameStatus>().IsGameOver();

        if(!isGameOver){
            MovementType2();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver){
            leftClick = Input.GetAxis("Fire1");
            if(Input.GetMouseButtonDown(0) && leftClick > 0f){
                initialMousePosX = Input.mousePosition.x;
            }
    }
    }


    void MovementType2(){

        if(leftClick > 0f && initialMousePosX > screenWidth / 2){
             rb.velocity = new Vector2(leftClick * moveSpeed , rb.velocity.y); 
        } else if(leftClick > 0f && initialMousePosX < screenWidth / 2){
            rb.velocity = new Vector2(leftClick * -moveSpeed , rb.velocity.y); 
        } else if (leftClick <= 0f){
             rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Cactus")){
            rb.velocity = new Vector2(0,0);
            FindObjectOfType<GameStatus>().SetGameOver(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.CompareTag("ScoreTrigger")){
            FindObjectOfType<GameStatus>().AddToScore();
       }
   }

    // void MovementType1(){
    //  leftClick = Input.GetAxis("Fire1");

    //    if(leftClick > 0f){
    //          rb.velocity = new Vector2(leftClick * moveSpeed , rb.velocity.y); 
    //     } else if(leftClick <= 0f){
    //          rb.velocity = new Vector2(0, rb.velocity.y);
    //     }
    // }

}
