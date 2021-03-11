﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{

    private float moveSpeed;
    private Rigidbody2D rb;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
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


    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            rb.velocity = new Vector2(0,0);
        }
    }
}
