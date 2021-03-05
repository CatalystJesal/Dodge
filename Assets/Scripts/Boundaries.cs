using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    private float boundaryLeft;
    private float boundaryRight;

    private float screenWidth;

    private Rigidbody2D rb;
    private Collider2D collider;

    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {

        screenWidth = Screen.width;
        
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        //Gets the left x coordinate of the left-end of the screen 
        boundaryLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z)).x;
        //Gets the right x coordinate of the right-end of the screen 
        boundaryRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x;
        objectWidth = collider.bounds.size.x / 2;

        // Debug.Log("screen left: " + boundaryLeft);
        Debug.Log("screen right: " + boundaryRight);
    }

    void FixedUpdate(){
    

    }

    // Update is called once per frame
    void LateUpdate()
    {
    if(Input.GetMouseButtonDown(0)){
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log(worldPosition);
        }

        Vector2 newPos; 

        if(rb.position.x + objectWidth >= boundaryRight){
                newPos = new Vector2(boundaryLeft + 0.4f, rb.position.y);
                rb.MovePosition(newPos);

        } else if(rb.position.x - objectWidth <= boundaryLeft) {
                newPos = new Vector2(boundaryRight - 0.4f, rb.position.y);
                rb.MovePosition(newPos);
        }
    }
}
