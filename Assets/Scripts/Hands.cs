using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    //Fields
    [SerializeField] Transform forceOrigin;
    [SerializeField] Transform holdTransform;

    List<Rigidbody> entityList = new List<Rigidbody>();

    Rigidbody heldEntity = null;

    public float launchFor = 40;

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

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < entityList.Count; i++) {
            if (entityList[i] == null)
                entityList.RemoveAt(i);
        }

        if(heldEntity != null) {
            heldEntity.gameObject.tag = "Projectile";
            Vector3 smoothPose = Vector3.Lerp(heldEntity.position, holdTransform.position, 0.15f);
            heldEntity.MovePosition(smoothPose);
        }

        if (Input.GetButtonDown("Fire1")) {
            if(heldEntity != null) {
                heldEntity.isKinematic = false;
                Vector3 forceVec = holdTransform.transform.forward.normalized * launchFor;
                heldEntity.AddForce(forceVec, ForceMode.VelocityChange);
                heldEntity = null;
                return;
            }
            foreach (Rigidbody entity in entityList) {
                Vector3 entityPos = entity.GetComponent<Transform>().position;
                Vector3 forceVec = entityPos - forceOrigin.position;
                float scalingForce = 100 * Mathf.Exp(3 / forceVec.magnitude);
                forceVec.Normalize();
                entity.AddForce(forceVec * scalingForce);
            }
        }

        if (Input.GetButtonDown("Fire2")) {
            if(heldEntity != null) {
                heldEntity.isKinematic = false;
                heldEntity = null;
                return;
            }
            if (entityList.Count != 0) {
                float minDist = float.MaxValue;
                foreach (Rigidbody entity in entityList) {
                    Vector3 entityPos = entity.GetComponent<Transform>().position;
                    Vector3 dispVec = entityPos - forceOrigin.position;
                    if (dispVec.magnitude < minDist) {
                        heldEntity = entity;
                        minDist = dispVec.magnitude;
                    }
                }
                heldEntity.isKinematic = true;
            }
        }
    }

}
