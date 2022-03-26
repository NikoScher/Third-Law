using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveInitForce : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float initForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 forceVec = transform.forward.normalized * initForce;
        rb.AddForce(forceVec / rb.mass, ForceMode.VelocityChange);
    }
}
