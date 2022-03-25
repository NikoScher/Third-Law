using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Upon a collision
    private void OnCollisionEnter(Collision c)
    {
        // If the object collided with is marked as deadly
        if (c.gameObject.tag == "Deadly")
            Destroy(gameObject);
    }
}
