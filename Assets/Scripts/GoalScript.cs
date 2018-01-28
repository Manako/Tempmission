using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour {

    public string Next_Level;

    private void Start()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        Camera.main.transform.GetComponent<MenuScript>().startAudio(current_scene.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "player")
        {
            
            if (collision.transform.GetComponent<Collect_Bits>().bitCount == 8)
            {
                GameObject player = GameObject.Find("Player");
                player.GetComponent<Collect_Bits>().newScene();

                Scene current_scene = SceneManager.GetActiveScene();
                SceneManager.UnloadSceneAsync(current_scene);
                SceneManager.LoadScene(Next_Level, LoadSceneMode.Additive);
            }

        }
    }
}
