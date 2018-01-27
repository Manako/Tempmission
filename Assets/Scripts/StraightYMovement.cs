using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightYMovement : MonoBehaviour
{
    public float maxY = 100;
    public float minY = 0;

    float move;
    bool movingUp;
    // Use this for initialization
    void Start()
    {

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
