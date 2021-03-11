using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //Have the trigger on one of the cactus's instead? Score isn't updating immediately and trigger gets mis-placed elsewhere causing this issue
        private Rigidbody2D rb;
        private float moveSpeed;

        private bool isGameOver;

        void Start(){

            rb = this.GetComponent<Rigidbody2D>();
            moveSpeed = FindObjectOfType<GameStatus>().CactusSpeed();
            rb.velocity = new Vector2(0, -moveSpeed);

        }

        void FixedUpdate(){
            isGameOver = FindObjectOfType<GameStatus>().IsGameOver();

            if(isGameOver){
                 rb.velocity = new Vector2(0, 0);
            }
        }

}
