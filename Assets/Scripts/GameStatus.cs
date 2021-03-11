using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int scorePerClear = 1;
    [SerializeField] int currentScore = 0;


    [SerializeField] bool isGameOver;

    [SerializeField] float cactusSpeed;


    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Start()
    {
        isGameOver = false;
    }

    public float CactusSpeed(){
        return cactusSpeed;
    }


    public void AddToScore(){
        currentScore += scorePerClear;
        scoreText.text = "Score: " + currentScore;
    }

    public bool IsGameOver(){
        return isGameOver;
    }

    public void SetGameOver(bool b){

        if(!isGameOver){
            isGameOver = b;
            Debug.Log("GAME OVER");
        }
       
    }
}
