using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightYMovement : MonoBehaviour
{
    float maxY = 100;
    float minY = 0;

    public float moveDistance;

    float move;
    bool movingUp;
    // Use this for initialization
    void Start()
    {
        if (moveDistance > 0)
        {
            minY = transform.position.y;
            maxY = transform.position.y + moveDistance;
        }
        else
        {
            minY = transform.position.y + moveDistance;
            maxY = transform.position.y;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > maxY)
        {
            movingUp = false;
        }
        else if (transform.position.y < minY)
        {
            movingUp = true;
        }

        if (movingUp)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }



    }
}
