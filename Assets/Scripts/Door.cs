using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public bool latch;
    private bool hasLatched;
    public GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonPressed()
    {
        if((latch && !hasLatched) || (!latch))
        {
            door.SetActive(!door.activeSelf);
            hasLatched = true;
        }
    }
}
