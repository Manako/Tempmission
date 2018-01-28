using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeWhenHit : MonoBehaviour {
    public float DeathTime = 250;
    float LifeTime = 0;
    public GameObject BitSparkle;
    public GameObject BitGlow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LifeTime++;
        if (LifeTime > DeathTime)
        {
            Explode();
        }
	}

    public void Explode()
    {
        GameObject glow = (GameObject)Instantiate(BitGlow, transform.position, transform.rotation);
        GameObject sparkle = (GameObject)Instantiate(BitSparkle, transform.position, transform.rotation);
        Destroy(transform.gameObject);

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        Explode();
    }

}
