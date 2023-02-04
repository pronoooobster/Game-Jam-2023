using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastElements : MonoBehaviour
{
    public GameObject selectedGameObject;
    
    private Camera playerCamera;
    private readonly int maxRayDistance = 100;
    private Vector3 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        selectedGameObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;

        RaycastHit2D hit = Physics2D.Raycast(playerCamera.ScreenToWorldPoint(mousePosition), transform.position, maxRayDistance);

        if(Input.GetMouseButtonDown(0) && hit.collider != null)
        {
            Debug.Log(hit.transform.name);
            selectedGameObject = hit.transform.gameObject;
        }
    }
}
