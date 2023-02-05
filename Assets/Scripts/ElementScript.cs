using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        // delete the element when it collides with the element
        if (other.gameObject.tag == "Element") {
            Destroy(gameObject);
        }
    }
}
