using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool hasLatched;
    public bool latch;
    public GameObject door;
    
    void ButtonPressed()
    {
        if((latch && !hasLatched) || !latch) {
            door.SetActive(!door.activeSelf);
            hasLatched = true;
        }
    }
}
