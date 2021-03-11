using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //add all the cactus objects to this list
    [SerializeField]
    private List<GameObject> cactusPrefabs;

    public float respawnTime = 1.5f;

    private Vector2 boundaryLeft;
    private Vector2 centreScreen;

    private Vector3 localScale;

    private Vector3 cactusSize;

    private float gapBetweenCactus;

    private int branchToSpawn;

    private bool isGameOver;

    private int prevBranchSpawn;

    // Start is called before the first frame update
    void Start()
    {
        centreScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, Camera.main.transform.position.z));

        branchToSpawn = Random.Range(0, cactusPrefabs.Count-1);

        StartCoroutine(CactusWave());
    }

    void FixedUpdate() {
           isGameOver = FindObjectOfType<GameStatus>().IsGameOver();
    }

    private void SpawnCactus(){

        GameObject currentBranch = Instantiate(cactusPrefabs[branchToSpawn]) as GameObject;
    
        currentBranch.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        branchToSpawn = Random.Range(0, cactusPrefabs.Count-1);


    }

    IEnumerator CactusWave(){
        //Only spawn new cactus if !GameOver

        while(!isGameOver){
            yield return new WaitForSeconds(respawnTime);
            SpawnCactus();
        } 


    }
}
