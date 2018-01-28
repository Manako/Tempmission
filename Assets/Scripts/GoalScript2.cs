using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript2 : MonoBehaviour
{
    public float delay;
    private string Scene_name;
    private GameObject player;
    private int bits;
    private int loaded = 0;
    bool anim_start = false;
    void Start()
    {
        player = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Player;
        Scene_name = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Next_Scene_Name;
        bits = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Bits_Needed;
    }

    private void Update()
    {
        if (anim_start)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                //Load next scene
                if(loaded == 0)
                {
					SceneManager.UnloadSceneAsync("Level_Overlay");
                    Scene current_scene = SceneManager.GetActiveScene();
                    SceneManager.UnloadSceneAsync(current_scene);
					SceneManager.LoadScene ("Level_Overlay");
                    SceneManager.LoadScene(Scene_name, LoadSceneMode.Additive);
                    loaded = 1;
                }
                   
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "player")
        {
            player = gameObject.transform.parent.GetComponent<Plug_Goal_Input>().Player;
            if (player.GetComponent<Collect_Bits>().bitCount == bits)
            {
                anim_start = true;
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<Camera_Follow>().enabled = true;
                Destroy(collision.gameObject);
            }

        }
    }
}
