using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] 
    public int scorePerClear = 1;
    [SerializeField] 
    public int currentScore = 0;


    [SerializeField] 
    public bool isGameOver;

    [SerializeField] 
    public float cactusSpeed;


    public TextMeshProUGUI scoreText;


    void Awake(){
        SetupSingleton();
    }

    
    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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

    public void ResetGame(){
        Destroy(gameObject);
    }

}