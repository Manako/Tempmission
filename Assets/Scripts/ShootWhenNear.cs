using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootWhenNear : MonoBehaviour {

    public Transform Player;
    public float MoveSpeed = 1.5f;

    public GameObject Ammo;

    public float TimeBetweenShots;
    float MaxDist = 10;
    float MinDist = 0;
    float shootTime = 0;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    void Update()
    {
        //transform.LookAt(Player);

        //transform.right = Player.position - transform.position;


        if (Vector3.Distance(transform.position, Player.position) >= MinDist && Vector3.Distance(transform.position, Player.position) < MaxDist)
        {

            //transform.position += transform.right * MoveSpeed * Time.deltaTime;


            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {
                shootTime++;
                if (shootTime > TimeBetweenShots)
                {
                    shootTime = 0;
                    GameObject ammoVar = (GameObject)Instantiate(Ammo, transform.position, transform.rotation);
                }
            }

        }
    }
}
