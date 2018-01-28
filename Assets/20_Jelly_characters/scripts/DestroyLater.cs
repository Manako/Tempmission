using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLater : MonoBehaviour
{
    float time;
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2)
        {
            Destroy(gameObject);
        }
    }
}
