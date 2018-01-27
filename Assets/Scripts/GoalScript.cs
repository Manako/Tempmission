using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

    public string Scene_name;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "player")
        {

            if(collision.transform.GetComponent<Collect_Bits>().bitCount == 8)
            {
                //Load next scene
                SceneManager.LoadScene(Scene_name, LoadSceneMode.Additive);
            }

        }
    }
}
