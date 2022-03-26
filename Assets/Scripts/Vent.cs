using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ඞ
public class Vent : MonoBehaviour
{
    [SerializeField] float force = 0.25f;
    public bool active = true;

    void OnTriggerStay(Collider c)
    {
        // Push code
        if(active && c.GetComponent<Rigidbody>() != null && !c.isTrigger)
            c.GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.VelocityChange);
    }

    public void ButtonPressed()
    {
        active = !active;
        if (active)
            GetComponent<ParticleSystem>().Play();
        else
            GetComponent<ParticleSystem>().Stop();
    }
}