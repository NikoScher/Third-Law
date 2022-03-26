using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen, latch;
    private bool alreadyTriggered;
    Animator am;
    

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        am.SetBool("character_nearby", isOpen);
    }

    void ButtonPressed()
    {
        //If the door is not latching, toggle it open/closed. If the door is latching, only toggle the first time.
        if(!latch || (latch && !alreadyTriggered))
        {
            isOpen = !isOpen;
            am.SetBool("character_nearby", isOpen);
            alreadyTriggered = true;
        }
        
    }
}
