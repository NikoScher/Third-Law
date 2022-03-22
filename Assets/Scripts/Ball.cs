using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //upon a collision
    private void OnTriggerEnter(Collider c)
    {
        //if the object collided with is marked as deadly
        if (c.tag == "Deadly")
        {
            //destroy the ball
            Destroy(this);
            Debug.Log("https://youtu.be/oiuyhxp4w9I?t=6");
        }
    }
}
