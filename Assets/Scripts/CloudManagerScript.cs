using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManagerScript : MonoBehaviour
{
   //Set this variable to your Cloud Prefab through the Inspector
    public GameObject cloudPrefab;
 
    //Set this variable to how often you want the Cloud Manager to make clouds in seconds.
    public float delay = 2;
 
    public static bool spawnClouds = true;
 
    void Start () {
        //Begin SpawnClouds Coroutine
        StartCoroutine(SpawnClouds());
    }
 
    IEnumerator SpawnClouds() {
        //This will always run
        while(true) {
            //Only spawn clouds if the boolean spawnClouds is true
            while(spawnClouds) {
                //Instantiate Cloud Prefab and then wait for specified delay, and then repeat
                Instantiate(cloudPrefab);
                yield return new WaitForSeconds(delay);
            }
        }
    }
} 

