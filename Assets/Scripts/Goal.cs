using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    
    public int nextSceneNum;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
     void OnCollisionEnter(Collision c)
    {   
        //if the player collides with the goal
        if (c.gameObject.tag == "Player")
        {
            //load the next level
            SceneManager.LoadScene(nextSceneNum);
        }
    }
}
