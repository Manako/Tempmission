using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public void exitApplication()
    {
        Debug.Log("Exiting application");
        Application.Quit();
    }
}
