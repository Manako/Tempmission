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
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
