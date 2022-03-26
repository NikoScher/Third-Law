using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailLogic : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    public bool latch = true;
    bool atEnd = false;

    [SerializeField] GameObject start;
    [SerializeField] GameObject end;
    [SerializeField] GameObject wall;
    Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {
        goalPos = end.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (latch) {
            wall.transform.position = Vector3.MoveTowards(wall.transform.position, goalPos, speed * Time.deltaTime);
            if (wall.transform.position == goalPos) {
                atEnd = !atEnd;
                if (atEnd) {
                    goalPos = start.transform.position;
                }
                else {
                    goalPos = end.transform.position;
                }
            }
        }
    }

    void ButtonPressed()
    {
        latch = !latch;
    }
}
