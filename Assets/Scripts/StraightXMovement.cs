using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightXMovement : MonoBehaviour {
    public float maxY = 100;
    public float minY = 0;

    float move;
    bool movingRight;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxY)
        {
            movingRight = false;
        }
        else if (transform.position.x < minY)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
    }

}
