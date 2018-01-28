using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hover : MonoBehaviour {
    private float deg;
	// Use this for initialization
	void Start () {
        deg = Random.value * 360;
	}
	
	// Update is called once per frame
	void Update () {
        deg += 1;
        gameObject.transform.Translate(Vector3.up * Mathf.Sin(deg/50) / 240);
    }
}
