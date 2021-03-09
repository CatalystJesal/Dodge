using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rb;
    private Collider2D collider;

    private float boundaryBottom;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        rb.velocity = new Vector2(0, -moveSpeed);
       
        boundaryBottom = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, Camera.main.transform.position.z)).y;

        Debug.Log("Cactus x coordinate: " + rb.position.x);

    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.y <= boundaryBottom){
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector2(0,0);
        }
    }
}
