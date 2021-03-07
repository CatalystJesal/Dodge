using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float respawnTime = 1.5f;

    private Vector2 boundaryLeft;
    private Vector2 boundaryRight;

    private Vector3 localScale;

    private Vector3 cactusSize;

    // Start is called before the first frame update
    void Start()
    {
        boundaryLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.transform.position.z));
     
        boundaryRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // objectWidth = collider.bounds.size.x / 2;
        StartCoroutine(CactusWave());
    }

    private void SpawnCactus(){

        //Right-side cactus

        GameObject cactusRight = Instantiate(cactusPrefab) as GameObject;
        cactusSize = cactusRight.GetComponent<Collider2D>().bounds.size;
      
        localScale =  cactusRight.transform.localScale;
        localScale.x = 2;
        cactusRight.transform.localScale = localScale;
        cactusRight.transform.position = new Vector2(boundaryRight.x - (cactusSize.x), boundaryRight.y);


        //Left-side cactus
        GameObject cactusLeft = Instantiate(cactusPrefab) as GameObject;
        cactusSize = cactusLeft.GetComponent<Collider2D>().bounds.size;

        localScale.x = 2;
        cactusLeft.transform.localScale = localScale;
        cactusLeft.transform.position = new Vector2(boundaryLeft.x + (cactusSize.x), boundaryLeft.y);


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
