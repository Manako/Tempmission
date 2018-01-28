using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActorMovement : MonoBehaviour
{
    public AudioClip jumpsound;
    public AudioClip footsound;
    AudioSource audiosrc;
    public float speed;             //Floating point variable to store the player's movement speed.
    public float maxSpeed;
    public float slowingSpeed;
    bool FacingRight = true;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    Animator anim;                  //Store a reference to the animator to update animations.
    ParticleSystem jumpSparks;
    //Vars used to check if grounded, so we know when we can jump.
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.3f;
    public LayerMask whatIsGround;
    public float fallMultiplier = 2.5f;

    //Variables related to death and resetting the player to their original location.
    bool isDead = false;
    float dying = 0;
    public float killY = -25;
    Vector2 startPosition;

    private int timer;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        startPosition = transform.position;
        jumpSparks = GetComponent<ParticleSystem>();
        audiosrc = GetComponent<AudioSource>();
        timer = 0;
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetBool("beenDeadForAwhileThereMate", true);
        anim.SetBool("dead", true);
        anim.SetBool("ground", true);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (isDead)
        {
            if (dying > 30)
            {
                anim.SetBool("dead", false);
            }
            anim.SetBool("ground", true);
            dying++;
            if (dying > 200)
            {
                //Application.LoadLevel(Application.loadedLevel);
                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    Scene s = SceneManager.GetSceneAt(i);
                    if (s.isLoaded)
                    {
                        SceneManager.LoadScene(SceneManager.GetSceneAt(i).buildIndex);
                    }
                }
            }
            return;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("ground", grounded);
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if( (Mathf.Abs(rb2d.velocity.x) < maxSpeed) || Mathf.Sign(movement.x) != Mathf.Sign(rb2d.velocity.x))
        {
            rb2d.AddForce(movement * speed);
        }
        if (moveHorizontal > 0 && !FacingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && FacingRight)
        {
            Flip();
        }

        anim.SetFloat("speedX", Mathf.Abs(moveHorizontal));

        anim.SetBool("ground", true);

        if (transform.position.y < killY)
        {
            Die();
        }

        if(timer == 20)
        {
            audiosrc.PlayOneShot(footsound);
            timer = 0;
        }
        else if(grounded && (Mathf.Abs(rb2d.velocity.x) > 1))
        {
            timer++;
        }
    }

    void Update()
    {
        if (isDead)
            return;

        // jump if key pressed
        if (/*rb2d.velocity.y < 1.5f  &&*/ grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            audiosrc.PlayOneShot(jumpsound);
            rb2d.velocity += (Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1)) / 2;// * Time.deltaTime;
            anim.SetBool("ground", false);
            jumpSparks.Play();
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector2 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.GetComponent<StraightXMovement>() || col.gameObject.GetComponent<StraightYMovement>())
        {
            if (transform.position.y > col.transform.position.y + col.collider.bounds.size.y)
                transform.parent = col.transform;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<StraightXMovement>() || col.gameObject.GetComponent<StraightYMovement>())
        {
            transform.parent = null;
        }
    }

}