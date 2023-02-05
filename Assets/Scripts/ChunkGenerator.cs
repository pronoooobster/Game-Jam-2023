using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
    public GameObject chunkPrefab;
    public float offsetY = 0;
    public float lowestChunkY = 0;
    public int initialChungSize = 10;
    public int currentDepth = 0;

    // coal spawn chance
    public float coalChance = 0.3f;
    // rock spawn chance
    public float rockChance = 0.3f;
    // gem spawn chance
    public float gemChance = 0.15f;
    // crystal spawn chance
    public float crystalChance = 0.1f;

    // spawn horizontal range
    public float spawnRangeX = 0.5f;
    // spawn vertical range
    public float spawnRangeY = 0.5f;

    // array of coal element options
    public GameObject[] coalElements;
    // array of rock element options
    public GameObject[] rockElements;
    // array of gem element options
    public GameObject[] gemElements;
    // array of crystal element options
    public GameObject[] crystalElements;

    // Start is called before the first frame update
    void Start()
    {
        lowestChunkY = GenerateChunk(transform.position, initialChungSize);
    }

    public void GenerateLayer(Vector2 positionInitial)
    {
                            //! generating dirt
        // offset the y position by the offsetY
        positionInitial.y += offsetY;
        // create a new Vector3 with the x and y positions
        Vector3 position = new Vector3(positionInitial.x, positionInitial.y, 0);
        // spawn the dirt layer
        GameObject layer = Instantiate(chunkPrefab, position, Quaternion.identity);
        // set the parent of the dirt layer to the ChunkGenerator
        layer.transform.parent = transform;

                            //! generating elements
        // spawn the coal elements with a chance in the random position in the range
        if (Random.value < coalChance) {
            // get a random position in the range
            Vector2 positionRandom = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
            // add the random position to the initial position
            positionRandom += positionInitial;
            // create a new Vector3 with the x and y positions
            Vector3 positionCoal = new Vector3(positionRandom.x, positionRandom.y, -1);
            // spawn the coal element
            GameObject coal = Instantiate(coalElements[Random.Range(0, coalElements.Length)], positionCoal, Quaternion.identity);
            // set the parent of the coal element to the dirt layer
            coal.transform.parent = layer.transform;
        }

        // spawn the rock elements with a chance in the random position in the range
        if (Random.value < rockChance) {
            // get a random position in the range
            Vector2 positionRandom = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
            // add the random position to the initial position
            positionRandom += positionInitial;
            // create a new Vector3 with the x and y positions
            Vector3 positionRock = new Vector3(positionRandom.x, positionRandom.y, -1);
            // spawn the rock element
            GameObject rock = Instantiate(rockElements[Random.Range(0, rockElements.Length)], positionRock, Quaternion.identity);
            // set the parent of the rock element to the dirt layer
            rock.transform.parent = layer.transform;
        }

        // spawn the gem elements with a chance in the random position in the range
        if (Random.value < gemChance) {
            // get a random position in the range
            Vector2 positionRandom = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
            // add the random position to the initial position
            positionRandom += positionInitial;
            // create a new Vector3 with the x and y positions
            Vector3 positionGem = new Vector3(positionRandom.x, positionRandom.y, -1);
            // spawn the gem element
            GameObject gem = Instantiate(gemElements[Random.Range(0, gemElements.Length)], positionGem, Quaternion.identity);
            // set the parent of the gem element to the dirt layer
            gem.transform.parent = layer.transform;
        }

        // spawn the crystal elements with a chance in the random position in the range
        if (Random.value < crystalChance) {
            // get a random position in the range
            Vector2 positionRandom = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
            // add the random position to the initial position
            positionRandom += positionInitial;
            // create a new Vector3 with the x and y positions
            Vector3 positionCrystal = new Vector3(positionRandom.x, positionRandom.y, -1);
            // spawn the crystal element
            GameObject crystal = Instantiate(crystalElements[Random.Range(0, crystalElements.Length)], positionCrystal, Quaternion.identity);
            // set the parent of the crystal element to the dirt layer
            crystal.transform.parent = layer.transform;
        }
        
        ++currentDepth;
    }

    public float GenerateChunk(Vector2 position, int layers)
    {
        // loop through the layers
        for (int i = 0; i < layers; i++) {
            // generate a layer
            GenerateLayer(position);
            // increase the y position by the offsetY
            position.y += offsetY;
        }

        // return the end for the last layer
        return position.y;
    }
}
