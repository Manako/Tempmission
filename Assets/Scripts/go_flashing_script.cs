using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_flashing_script : MonoBehaviour {
    GameObject parent;
    private int bits;
    float deg;
	// Use this for initialization
	void Start () {
        deg = 0;
        parent = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Player;
        bits = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Bits_Needed;
    }
	
	// Update is called once per frame
	void Update () {
        parent = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Player;
        if (parent != null)
        {
            if (parent.GetComponent<Collect_Bits>().bitCount == bits)
            {
                deg += (float).1;
                gameObject.GetComponent<SpriteRenderer>().enabled = (Mathf.Sin(deg) > 0);
                if (deg > 360)
                    deg -= 360;
            }
        }

    }
}
