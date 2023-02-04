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

    // Start is called before the first frame update
    void Start()
    {
        lowestChunkY = GenerateChunk(transform.position, 10);
    }

    public void GenerateLayer(Vector2 positionInitial)
    {
        // offset the y position by the offsetY
        positionInitial.y += offsetY;
        // create a new Vector3 with the x and y positions
        Vector3 position = new Vector3(positionInitial.x, positionInitial.y, 0);
        // spawn the layer
        GameObject layer = Instantiate(chunkPrefab, position, Quaternion.identity);
        // set the parent of the layer to the ChunkGenerator
        layer.transform.parent = transform;
        
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
