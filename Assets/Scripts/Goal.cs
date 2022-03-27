using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject goalPos;
    [SerializeField] float speed = 1.0f;
    bool reached = false;

    GameObject player = null;

    public int nextSceneNum;

    // Update is called once per frame
    void Update()
    {
        if (reached) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, goalPos.transform.position, speed * Time.deltaTime);
            Vector3 goalVec = goalPos.transform.position - player.transform.position;
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(goalVec), 0.1f);
            if (goalVec.magnitude < 0.01)
                SceneManager.LoadScene(nextSceneNum);
        }
    }

    void OnCollisionEnter(Collision c)
    {   
        // If the player collides with the goal
        if (c.gameObject.tag == "Player") {
            player = c.gameObject;
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Collider>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Animator>().SetInteger("AnimationPar", 1);
            reached = true;
        }
    }
}
