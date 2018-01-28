using UnityEngine;
using System.Collections;

public class JellyDeath : MonoBehaviour
{
    public bool dead;
    GameObject shadow;
    GameObject splash;
    AudioClip au;
    AudioSource source;
    void Start()
    {
        splash = Resources.Load("Smokex") as GameObject;  
        au = Resources.Load("squish") as AudioClip;
        source = GetComponent<AudioSource>();
        shadow = transform.GetChild(0).gameObject;
    
    }
    void Update()
    {  
        if (dead && !gameObject.GetComponent<Animator>().GetBool("dead"))
        {
            dieMethod();
        }
        if (dead)
        {
            dead = !dead;
        }
    }
    public void dieMethod()
    {
        if (gameObject.GetComponent<Collider2D>().isTrigger != true)
        {
            Destroy(shadow);
            gameObject.GetComponent<Animator>().SetBool("dead", true);
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder--;
            GameObject G = Instantiate(splash, transform.position, transform.rotation) as GameObject;
            G.SetActive(true);
            source.PlayOneShot(au, .5f);
         }
    }
}
