using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectRoot()
    {
        Color tmp = spriteRenderer.color;
        tmp.a = 0.5f;

        spriteRenderer.color = tmp;
    }

    public void unselectRoot()
    {
        Color tmp = spriteRenderer.color;
        tmp.a = 1f;

        spriteRenderer.color = tmp;
    }
}
