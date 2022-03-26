using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool latch;

    Animator am;
    

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        am.SetBool("character_nearby", latch);
    }

    void ButtonPressed()
    {
        latch = !latch;
        am.SetBool("character_nearby", latch);
    }
}
