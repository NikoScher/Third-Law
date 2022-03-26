using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Fields
    [SerializeField] Transform holdTransform;
    List<Rigidbody> entityList = new List<Rigidbody>();
    Rigidbody heldEntity = null;

    Rigidbody rb;
    public float launchFor = 1;

    Animator am;
    int currAni = 0;

    [SerializeField] float grabMaxTime = 1.0f;
    float grabTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        am = GetComponent<Animator>();
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

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Deadly")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < entityList.Count; i++) {
            if (entityList[i] == null)
                entityList.RemoveAt(i);
        }

        grabTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F)) {
            currAni = 2 - currAni;
            am.SetInteger("AnimationPar", currAni);
        }

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
        Vector3 targetVec = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetVec), 0.5f);

        if(heldEntity != null) {
            Vector3 smoothPose = Vector3.Lerp(heldEntity.position, holdTransform.position, 0.1f);
            heldEntity.MovePosition(smoothPose);
            Quaternion targetQuat = Quaternion.LookRotation(targetVec) * Quaternion.Euler(90, 0, 0);
            heldEntity.gameObject.transform.rotation = Quaternion.Slerp(heldEntity.gameObject.transform.rotation, targetQuat, 0.5f);
        }

        // Throw
        if (Input.GetButtonDown("Fire1") && heldEntity != null) {
            heldEntity.velocity = rb.velocity;
            Vector3 forceVec = holdTransform.transform.forward.normalized * launchFor;
            heldEntity.AddForce(forceVec / heldEntity.mass, ForceMode.VelocityChange);
            heldEntity = null;
            rb.AddForce(-forceVec, ForceMode.VelocityChange);
            grabTimer = grabMaxTime;
            return;
        }

        // Pickup
        if (Input.GetButtonDown("Fire2") && grabTimer < 0) {
            if(heldEntity != null) {
                heldEntity.velocity = rb.velocity;
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
                rb.velocity = (rb.mass*rb.velocity + heldEntity.mass*heldEntity.velocity) / (rb.mass + heldEntity.mass);
                heldEntity.velocity = rb.velocity;
            }
        }
    }

}