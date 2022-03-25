using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    
    public int nextSceneNum;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollisionEnter(Collision c)
    {   
        // If the player collides with the goal
        if (c.gameObject.tag == "Player")
            SceneManager.LoadScene(nextSceneNum);
    }
}
