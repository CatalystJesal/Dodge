using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other) {
       if(other.gameObject.CompareTag("Cactus")){
            Debug.Log("Destroying CactusBranch...");
            Destroy(other.gameObject.transform.parent.gameObject);
       }
   }
}
