using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLoader : MonoBehaviour
{
    [SerializeField]
    private float delay = 1.0f;


    public void GoToHome()
    {
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            FindObjectOfType<GameStatus>().ResetGame();
            FindObjectOfType<SpriteHandler>().Reset();
        }

        SceneManager.LoadScene("MenuScene");
    }

    public void GoToStore()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void GoToGame()
    {
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            FindObjectOfType<GameStatus>().ResetGame();
        }

        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad_GameOver());
    }

    public IEnumerator WaitAndLoad_GameOver()
    {
        // Debug.Log("Game Over Scene");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOverScene");
    }

}
