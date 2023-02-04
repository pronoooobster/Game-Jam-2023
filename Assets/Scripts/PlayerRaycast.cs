using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    /*
     * TODO: Be able to select and unselect the branches
     */
    [Header("Settings")]
    public LayerMask isClickable;
    public Transform gameMap;

    [Header("Debug")]
    public Root selectedRoot;

    private Camera playerCamera;
    private Vector3 mousePosition;

    private readonly int maxRayDistance = 100;


    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        selectedRoot = null;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = InputManager.Instance.Current.MousePosition;

        RaycastHit2D hit = Physics2D.Raycast(playerCamera.ScreenToWorldPoint(mousePosition), transform.position, maxRayDistance, isClickable);

        // If you hit something in the layermask
        if (InputManager.Instance.Current.SelectInput && hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Root"))
            {
                if (selectedRoot != null)
                {
                    selectedRoot.UnselectRoot();
                    selectedRoot = null;
                }

                selectedRoot = hit.transform.gameObject.GetComponent<Root>();
                selectedRoot.SelectRoot();
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Temp Root"))
            {
                // Create a root in the tempRoot's position and assign it to the selectedRoot's root list
                Transform newRootTransform = hit.collider.transform.parent; // Game Map transform
                Root newRoot = selectedRoot.AddRoot(newRootTransform);
                
                selectedRoot.UnselectRoot();
                selectedRoot = newRoot;
            }
        }
        // If you hit something not in the layermask
        else if (InputManager.Instance.Current.SelectInput && hit.collider == null && selectedRoot)
        {
            selectedRoot.UnselectRoot();
            selectedRoot = null;
        }
    }
}
