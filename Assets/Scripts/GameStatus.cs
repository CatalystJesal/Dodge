using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int scorePerClear = 1;
    [SerializeField] int currentScore = 0;



    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddToScore(){
        currentScore += scorePerClear;
    }
}
