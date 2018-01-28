using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript2 : MonoBehaviour
{
    public float delay;
    public GameObject player;
    bool anim_start = false;
    void Create()
    {
    }

    private void Update()
    {
        if (anim_start)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                //Load next scene
                SceneManager.LoadScene(Scene_name, LoadSceneMode.Additive);
            }
        }
    }

    public string Scene_name;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "player")
        {
            if (collision.transform.GetComponent<Collect_Bits>().bitCount == 8)
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
