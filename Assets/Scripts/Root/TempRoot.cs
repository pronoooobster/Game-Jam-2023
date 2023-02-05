using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempRoot : MonoBehaviour
{
    private bool isPossible;

    // Start is called before the first frame update
    void Start()
    {
        isPossible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsPossible()
    {
        return isPossible;
    }

    public void SetIsPossible(bool value)
    {
        isPossible = value;
    }
}
