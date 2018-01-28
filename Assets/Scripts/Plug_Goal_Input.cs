using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug_Goal_Input : MonoBehaviour {
    public GameObject Player;
    public string Next_Scene_Name;
    public int Bits_Needed;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        gameObject.transform.GetChild(3).GetComponent<TextHandler>().position.x = Screen.width/2 - 256/2;
        gameObject.transform.GetChild(3).GetComponent<TextHandler>().position.y = Screen.height/2 + 60;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
