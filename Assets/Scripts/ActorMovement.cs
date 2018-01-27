using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActorMovement : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.
    public float maxSpeed;
    bool FacingRight = true;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    Animator anim;                  //Store a reference to the animator to update animations.

    //Vars used to check if grounded, so we know when we can jump.
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public float jumpForce = 200.0f;
    public LayerMask whatIsGround;

    //Variables related to death and resetting the player to their original location.
    bool isDead = false;
    float dying = 0;
    public float killY = -25;
 

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void Die()
    {
        if (isDead)
            return;

        isDead = true;
        //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;

        anim.SetBool("beenDeadForAwhileThereMate", true);
        anim.SetBool("dead", true);
        anim.SetBool("ground", true);
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (isDead)
        {
            anim.SetBool("dead", false);
            anim.SetBool("ground", true);
            dying++;
            if (dying > 200)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            return;
        }

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("ground", grounded);
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        if (moveHorizontal < maxSpeed)
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
        anim.SetFloat("speedY", Mathf.Abs(moveVertical));

        anim.SetBool("ground", true);

        if (transform.position.y < killY)
        {
            Die();
        }
    }

    void Update()
    {
        if (isDead)
            return;

        // jump if key pressed
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
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