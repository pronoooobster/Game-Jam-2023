using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Root : MonoBehaviour
{
    private static readonly int maxNextRoots = 2;

    [Header("Settings")]
    public GameObject rootPrefab;
    public Transform endNode;

    // variables for images of selected and unselected root
    public Sprite selectedSprite;
    public Sprite unselectedSprite;

    [SerializeField]
    private List<Root> nextRoots;
    
    [SerializeField]
    private List<GameObject> tempRoots;

    private SpriteRenderer spriteRenderer;

    [Header("Debug")]
    public float parentAngleDebug;

    private void Start()
    {
        nextRoots = new List<Root>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        UnselectRoot();

        //updating the deepest point
        if (endNode.position.y < RootManager.Instance.DeepestPoint)
        {
            RootManager.Instance.DeepestPoint = transform.position.y;
        }
    }
    public bool CanSelect()
    {
        return nextRoots.Count < 2;
    }

    public void SelectRoot()
    {
        // Change the alpha channel of the sprite
        Color tmp = spriteRenderer.color;
        tmp.a = 1f;

        // Change the sprite
        spriteRenderer.sprite = selectedSprite;

        spriteRenderer.color = tmp;

        ShowTempRoots();
    }

    public void UnselectRoot()
    {
        // Change the alpha channel of the sprite
        Color tmp = spriteRenderer.color;
        tmp.a = 1f;

        // Change the sprite
        spriteRenderer.sprite = unselectedSprite;

        spriteRenderer.color = tmp;

        HideTempRoots();
    }

    private void ShowTempRoots()
    {
        foreach (GameObject root in tempRoots)
        {
            //if(root.GetComponent<TempRoot>().GetIsPossible())
            root.SetActive(true);
        }
    }

    private void HideTempRoots()
    {
        foreach (GameObject root in tempRoots)
        {
            root.SetActive(false);
        }
    }

    public Root AddRoot(Transform newRootTransform)
    {
        Root newRoot = null;

        if(nextRoots.Count >= maxNextRoots)
        {
            return newRoot;
        }

        newRoot = Instantiate(rootPrefab).GetComponentInChildren<Root>();
        nextRoots.Add(newRoot);

        newRoot.transform.parent.parent = transform.parent.parent;

        newRoot.transform.parent.SetPositionAndRotation(newRootTransform.position, newRootTransform.rotation);

        newRoot.UpdateTempRootsAngles(newRootTransform.eulerAngles.z);

        //int index = tempRoots.IndexOf(newRootTransform.gameObject);
        //tempRoots[index].GetComponent<TempRoot>().SetIsPossible(false);

        // step the game forward in game manager
        GameManager.Instance.stepForward();

        return newRoot;
    }

    private void UpdateTempRootsAngles(float parentAngle)
    {
        for (int i = 0; i < tempRoots.Count; i++)
        {
            Transform tempRoot = tempRoots.ElementAt(i).transform;

            tempRoot.transform.rotation = Quaternion.Euler(0f, 0f, (i * 30) -60f);
        }
    }

    // on collision with another object
    private void OnTriggerEnter2D(Collider2D other) {
        // debvuug
        Debug.Log("Collision with " + other.gameObject.name);
        // check if the object is an element
        if(other.gameObject.tag == "Element") {
            // if the element is a rock
            if(other.gameObject.GetComponent<ElementScript>().type == 1) {
                
                StartCoroutine(FindObjectOfType<CameraShake>().Shake(.3f,.3f));

                // step the game forward in game manager
                GameManager.Instance.stepForward();

                // destroy the root
                Destroy(gameObject);
            } else {
                // add the element to the queue
                GameManager.Instance.addElement(other.gameObject.GetComponent<ElementScript>());
            }
        }
    }
}
