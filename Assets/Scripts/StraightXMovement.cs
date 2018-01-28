using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightXMovement : MonoBehaviour {
    float maxX = 100;
    float minX = 0;

    public float moveDistance;

    float move;
    bool movingRight;
    // Use this for initialization
    void Start()
    {
        if (moveDistance > 0)
        {
            minX = transform.position.x;
            maxX = transform.position.x + moveDistance;
        }
        else
        {
            minX = transform.position.x + moveDistance;
            maxX = transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > maxX)
        {
            movingRight = false;
        }
        else if (transform.position.x < minX)
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
