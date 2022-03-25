using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject onState;
    public GameObject[] interactObjects;

    bool active = false;

    void OnTriggerEnter(Collider c)
    {
        if (!c.isTrigger) {
            active = !active;
            GetComponent<MeshRenderer>().enabled = !active;
            onState.GetComponent<MeshRenderer>().enabled = active;

            foreach (GameObject g in interactObjects) {
                g.SendMessage("ButtonPressed");
            }
        }
    }
}
