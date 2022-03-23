using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    Rigidbody thisSpear;
    
    // Start is called before the first frame update
    void Start()
    {
        thisSpear = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision c)
    {
        //if the object collided with is marked as deadly
        if (c.gameObject.tag == "Deadly")
        {
            //lock the spear in place
            thisSpear.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
            Debug.Log("https://youtu.be/oiuyhxp4w9I?t=6");
        }
    }
}
