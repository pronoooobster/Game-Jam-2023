using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 2.0f;
    public float maxY = 20.0f;
    public float minY = 0.0f;
    private float y = 3.4f;
    private float camSafeZone = 0.0f;
    
    void Start()
    {
        y = transform.position.y;
        Camera camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            y -= Input.GetAxis("Mouse Y") * sensitivity * speed * Time.deltaTime;
            // clamp the y position
            y = Mathf.Clamp(y, minY, maxY);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        // update minY so the camera lowest end doesn't go below the lowest chunk
        float halfHeight = GetComponent<Camera>().orthographicSize;
        minY = GameObject.Find("Ground").GetComponent<ChunkGenerator>().lowestChunkY + halfHeight + camSafeZone;
    }
}