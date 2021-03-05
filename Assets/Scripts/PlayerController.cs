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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenWidth = Screen.width;
    }

    void FixedUpdate() {
        movementType2();
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    void movementType2(){

        leftClick = Input.GetAxis("Fire1");

        if(leftClick > 0f && Input.mousePosition.x > screenWidth / 2){
             rb.velocity = new Vector2(leftClick * moveSpeed , rb.velocity.y); 
        } else if(leftClick > 0f && Input.mousePosition.x < screenWidth / 2){
            rb.velocity = new Vector2(leftClick * -moveSpeed , rb.velocity.y); 
        } else if (leftClick <= 0f){
             rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    void movementType1(){
     leftClick = Input.GetAxis("Fire1");

       if(leftClick > 0f){
             rb.velocity = new Vector2(leftClick * moveSpeed , rb.velocity.y); 
        } else if(leftClick <= 0f){
             rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
