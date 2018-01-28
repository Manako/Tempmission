 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class HomingAttack : MonoBehaviour
{

    public Transform Player;
    public float MoveSpeed = 1.5f;
    float MaxDist = 10;
    float MinDist = 0;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        //transform.LookAt(Player);

        transform.right = Player.position - transform.position;


        if (Vector3.Distance(transform.position, Player.position) >= MinDist && Vector3.Distance(transform.position, Player.position) < MaxDist)
        {

            transform.position += transform.right * MoveSpeed * Time.deltaTime;
            

            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                //Something happens when close. Maybe projectiles? Maybe scaling?
            }

        }
    }
}
