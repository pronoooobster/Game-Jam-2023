using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementScript : MonoBehaviour
{
    // type of element
    // 0: water
    // 1: rock
    // 2: mineral (coal)
    // 3: gem
    public int type;

    public int endStep;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        // delete the element when it collides with the element
        // destroy the element with 50 precent chance
        if (other.gameObject.tag == "Element" && Random.value < 0.5f) {
            Destroy(gameObject);
        }
    }
}
