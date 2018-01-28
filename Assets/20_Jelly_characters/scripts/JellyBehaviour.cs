using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JellyBehaviour : MonoBehaviour
{

    float time, ActTime;
    bool toright;
    public Behaviour behaviour;
    void Start()
    {
        ActTime = Random.Range(1f, 4f);
        switch (behaviour)
        {
            case Behaviour.walker:
                gameObject.GetComponent<Collider2D>().sharedMaterial = Resources.Load("materials/firm") as PhysicsMaterial2D;
                break;
            case Behaviour.jumper:

                break;
            case Behaviour.floater:
                gameObject.GetComponent<Rigidbody2D>().gravityScale = .05f;
                break;
        }
    }
    public enum Behaviour
    {
        walker, jumper, floater,
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > ActTime)
        {
            time = 0;
            switch (behaviour)
            {
                case Behaviour.walker:

                    if (toright)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 0));
                    }
                    else
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 0));
                    }
                    toright = !toright;
                    break;
                case Behaviour.jumper:
                    if (toright)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, 150));
                    }
                    else
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 150));
                    }
                    toright = !toright;

                    break;
                case Behaviour.floater:

                    if (toright)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.RandomRange(20, 50), 30));
                    }
                    else
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.RandomRange(-50, -20), 30));
                    }
                    toright = !toright;
                    break;
            }
        }
    }
}
