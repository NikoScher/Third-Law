using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Fields
    [SerializeField] Transform holdTransform;
    List<Rigidbody> entityList = new List<Rigidbody>();
    Rigidbody heldEntity = null;

    Rigidbody rb;

    public float launchFor = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        Rigidbody entity;
        if(collider.GetComponent<Rigidbody>() != null) {
            entity = collider.GetComponent<Rigidbody>();
            Rigidbody checkEntity = entityList.Find(x=> x == entity);
            if (checkEntity == null)
                entityList.Add(entity);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Rigidbody entity = collider.GetComponent<Rigidbody>();
        entityList.Remove(entity);
    }

    
    private void OnCollisionEnter(Collision c)
    {
        //kill wall interaction
        //if the object collided with is marked as deadly
        if (c.gameObject.tag == "Deadly")
        {
            //destroy the ball
            Destroy(gameObject);
            Debug.Log("https://youtu.be/oiuyhxp4w9I?t=6");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(temp);
        Vector3 targetVec = mousePos - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetVec), 0.5f);

        if(heldEntity != null) {
            Vector3 smoothPose = Vector3.Lerp(heldEntity.position, holdTransform.position, 0.5f);
            heldEntity.MovePosition(smoothPose);
        }

        if (Input.GetButtonDown("Fire1") && heldEntity != null) {
            Vector3 forceVec = holdTransform.transform.forward.normalized * heldEntity.mass * launchFor;
            heldEntity.AddForce(forceVec, ForceMode.VelocityChange);
            heldEntity = null;
            rb.AddForce(-forceVec*0.25f, ForceMode.VelocityChange);
            return;
        }

        if (Input.GetButtonDown("Fire2")) {
            if(heldEntity != null) {
                heldEntity = null;
                return;
            }
            if (entityList.Count != 0) {
                float minDist = float.MaxValue;
                foreach (Rigidbody entity in entityList) {
                    Vector3 entityPos = entity.GetComponent<Transform>().position;
                    Vector3 dispVec = entityPos - transform.position;
                    if (dispVec.magnitude < minDist) {
                        heldEntity = entity;
                        minDist = dispVec.magnitude;
                    }
                }
            }
        }
    }

}