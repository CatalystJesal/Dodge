﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
        private Rigidbody2D rb;
        public float moveSpeed;

        void Start(){

            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -moveSpeed);

        }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            FindObjectOfType<GameStatus>().AddToScore();
       }
   }
}
