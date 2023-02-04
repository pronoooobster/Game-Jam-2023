using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Root : MonoBehaviour
{
    private static readonly int maxNextRoots = 2;

    [Header("Settings")]
    public GameObject tempRootPrefab;
    public GameObject rootPrefab;
    public Transform endNode;

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
    }

    public void SelectRoot()
    {
        // Change the alpha channel of the sprite
        Color tmp = spriteRenderer.color;
        tmp.a = 1f;

        spriteRenderer.color = tmp;

        ShowTempRoots();
    }

    public void UnselectRoot()
    {
        // Change the alpha channel of the sprite
        Color tmp = spriteRenderer.color;
        tmp.a = 0.5f;

        spriteRenderer.color = tmp;

        HideTempRoots();
    }

    private void ShowTempRoots()
    {
        foreach (GameObject root in tempRoots)
        {
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

        //newRoot.transform.parent.SetPositionAndRotation(newRootTransform.position, newRootTransform.rotation);
        newRoot.transform.parent.position = newRootTransform.position;
        newRoot.transform.parent.rotation = newRootTransform.rotation;

        newRoot.UpdateTempRootsAngles(newRootTransform.eulerAngles.z);

        return newRoot;
    }

    private void UpdateTempRootsAngles(float parentAngle)
    {
        for (int i = 0; i < tempRoots.Count; i++)
        {
            Transform tempRoot = tempRoots.ElementAt(i).transform;

            tempRoot.transform.rotation = Quaternion.Euler(0f, 0f, (i * 30) -60f);
        }
        //Debug.Log("update angles");
        //Debug.Log("Parent angle: " + parentAngle);

        //if (parentAngle >= 180 && parentAngle <= 360)
        //{
        //    parentAngle -= 360;
        //}

        //Debug.Log("Parent angle: " + parentAngle);

        //parentAngleDebug = parentAngle;

        //for (int i = 0; i < tempRoots.Count; i++)
        //{
        //    Transform tempRoot = tempRoots.ElementAt(i).transform;

        //    tempRoot.transform.rotation = Quaternion.Euler(tempRoot.eulerAngles.x, tempRoot.eulerAngles.y, tempRoot.eulerAngles.z + parentAngle);
        //}
    }
}
