using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            if (col.gameObject.GetComponent<ActorMovement>())
                col.gameObject.GetComponent<ActorMovement>().Die();
                //Destroy(col.gameObject);
        }
    }
}