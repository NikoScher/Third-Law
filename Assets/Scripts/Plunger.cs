using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider c)
    {
        // Lock the spear in place
        if (c.gameObject.tag != "Player" && c.gameObject.tag != "Deadly") {
            transform.SetParent(c.gameObject.transform.parent.transform, true);
            Destroy(rb);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Deadly")
            Destroy(gameObject);
    }
}
