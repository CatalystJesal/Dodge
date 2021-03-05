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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenWidth = Screen.width;
    }

    void FixedUpdate() {
        MovementType2();
    }

    // Update is called once per frame
    void Update()
    {
        leftClick = Input.GetAxis("Fire1");
        if(Input.GetMouseButtonDown(0) && leftClick > 0f){
            initialMousePosX = Input.mousePosition.x;
        }
    }


    void MovementType2(){

    //Need an event to track the initial mouse click position of the player
    //To only use the position of that initial click to prevent player from dragging
    //clicked mouse position which would change in real time and change player direction

        if(leftClick > 0f && initialMousePosX > screenWidth / 2){
             rb.velocity = new Vector2(leftClick * moveSpeed , rb.velocity.y); 
        } else if(leftClick > 0f && initialMousePosX < screenWidth / 2){
            rb.velocity = new Vector2(leftClick * -moveSpeed , rb.velocity.y); 
        } else if (leftClick <= 0f){
             rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    void MovementType1(){
     leftClick = Input.GetAxis("Fire1");

       if(leftClick > 0f){
             rb.velocity = new Vector2(leftClick * moveSpeed , rb.velocity.y); 
        } else if(leftClick <= 0f){
             rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

}
