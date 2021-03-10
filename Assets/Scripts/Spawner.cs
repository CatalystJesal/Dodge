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

    // Start is called before the first frame update
    void Start()
    {
        // boundaryLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z));
     
        centreScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, Camera.main.transform.position.z));

        // objectWidth = collider.bounds.size.x / 2;
        StartCoroutine(CactusWave());
    }

    private void SpawnCactus(){


        //Use Random.Range to select a number between the first index till the size of the cactusPrefabs list
        //instantiate that one

        branchToSpawn = Random.Range(0, cactusPrefabs.Count-1);

        GameObject currentBranch = Instantiate(cactusPrefabs[branchToSpawn]) as GameObject;
    
        currentBranch.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    


 
    
     

        //use Random.Range to determine whether to spawn one cactus or two cactus at the same time
        //{

        //Have two cactuses spawn at the same time at opposite ends but one of the two cactuses is longer than the other and there's a gap of the same length each time, ensure that the next spawing cactus
        //is offset from the first one spawned by x-gap
        //OR
        //Spawn only one cactus at random (use Random.Range to decide) decide if it's left one or right one, have it take up almost the entire width of the screen with the gap at the end

        //}
    }

    IEnumerator CactusWave(){
        //Instead only spawn new cactus if !GameOver
        while(true){
            yield return new WaitForSeconds(respawnTime);
            SpawnCactus();
        }
    }
}
