using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextDisplay : MonoBehaviour
{

    private TextMeshProUGUI scoreText;
    private GameStatus gameState;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameState = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = scoreText.text = "Score: " + gameState.GetScore();
    }
}
