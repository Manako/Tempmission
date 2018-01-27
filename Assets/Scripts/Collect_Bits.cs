using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_Bits : MonoBehaviour {

    public TextMesh bits_txt;
    public int bitCount = 0;

	void Start () {

        bits_txt.text = "";
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.transform.tag == "0_bit" || collision.transform.tag == "1_bit")
        {
            string bit = "";
            if (collision.transform.tag == "0_bit")
            {
                bit = "0 ";
            }
            else if (collision.transform.tag == "1_bit")
            {
                bit = "1 ";
            }

            Destroy(collision.transform.gameObject);

            bitCount++;
            bits_txt.text = bits_txt.text + bit;
        }      
    }

    private void FixedUpdate()
    {
        if (bitCount == 8)
            bits_txt.text = "Message received";
    }


}
