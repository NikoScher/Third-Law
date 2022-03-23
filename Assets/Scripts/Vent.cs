using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    
    public bool active, latch;
    private bool hasLatched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerStay(Collider c)
    {
        //push code
        if(active && (c.GetComponent<Rigidbody>() != null))
        {
            c.GetComponent<Rigidbody>().AddForce(-transform.forward*0.25f, ForceMode.VelocityChange);
        }



    }

    public void ButtonPressed()
    {
        if((latch && !hasLatched) || (!latch))
        {
            active = !active;
            hasLatched = true;
        }
    }



}
