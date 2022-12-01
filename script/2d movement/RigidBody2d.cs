using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class RigidBody2d : MonoBehaviour
{
    /*Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }*/

    Rigidbody2D player;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public Animator animatore;
    public AudioSource suonoPassi;

    public float runSpeed = 20.0f;

    bool m_FacingRight = true; //serve per flippare il personaggio

    void Start()
    {

        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //dò un valore a horizontal e vertical
        float destra = horizontal = Input.GetAxisRaw("Horizontal");
        float giu = vertical = Input.GetAxisRaw("Vertical");

        animatore.SetFloat("giu", giu);
        animatore.SetFloat("sinistra", destra);

        if (player.velocity.magnitude > 0)
        {
            if (!suonoPassi.isPlaying)
                suonoPassi.Play();
        }
        else
        {
            suonoPassi.Stop();
        }

    }

    private void FixedUpdate()
    {
        //controllo il movimento diagonale
        if (horizontal !=0 && vertical !=0)
        {
            //limita il movimento diagonale, così si muove al 70% della velocità
            horizontal = horizontal * moveLimiter;
            vertical = vertical * moveLimiter;
        }

        player.velocity = new Vector2(horizontal * runSpeed , vertical * runSpeed );

        // If the input is moving the player right and the player is facing left...
        if (horizontal > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontal < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
