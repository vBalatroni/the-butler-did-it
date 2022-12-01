using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xInput = 0, yInput = 0;
    bool mouseLeft, canShoot;
    float lastShot = 0, timeBetweenShots = 0.25f;
    Vector3 mousePos, mouseVector;
    public GameObject bulletPrefab;
    CameraController Cam;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement; //vettore di movimento
    //Vector2 mousePos;

    public Camera camPlayer;

    bool m_FacingRight = true;
    float horizontal;

    private void Start()
    {
        GetMouseInput();
        Cam = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        GetInput(); //capture wasd and mouse
        //Movement(); //move the player NON USARE, NON SERVE
        // Animation(); //rotate the gun
        // Shooting(); //handle shooting
    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical"); //capture wasd and arrow controls
        GetMouseInput();
    }

    void GetMouseInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of cursor in world
        mousePos.z = transform.position.z; //keep the z position consistant, since we're in 2d
        mouseVector = (mousePos - transform.position).normalized; //normalized vector from player pointing to cursor
        mouseLeft = Input.GetMouseButton(0); //check left mouse button
    }

    // void Animation()
    // {
    //     float gunAngle = -1 * Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg; //find angle in degrees from player to cursor
    //     gunSprite.rotation = Quaternion.AngleAxis(gunAngle, Vector3.back); //rotate gun sprite around that angle
    //     gunRend.sortingOrder = playerSortingOrder - 1; //put the gun sprite bellow the player sprite
    //     if (gunAngle > 0)
    //     { //put the gun on top of player if it's at the correct angle
    //         gunRend.sortingOrder = playerSortingOrder + 1;
    //     }
    // }

    // void Shooting()
    // {
    //     canShoot = (lastShot + timeBetweenShots < Time.time);
    //     if (mouseLeft && canShoot)
    //     { //shoot if the mouse button is held and its been enough time since last shot
    //         Vector3 spawnPos = gunTip.position; //position of the tip of the gun, a transform that is a child of rotating gun
    //         Quaternion spawnRot = Quaternion.identity; //no rotation, bullets here are round
    //         BulletAndrea bul = Instantiate(bulletPrefab, spawnPos, spawnRot).GetComponent<BulletAndrea>();//spawn bullet and capture it's script
    //         bul.Setup(mouseVector); //give the bullet a direction to fly
    //         lastShot = Time.time; //used to check next time this is called
    //         Cam.Shake((transform.position - gunTip.position).normalized, 1.5f, 0.05f); //call camera shake for recoil
    //     }
    // }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        /*Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;*/

        if (horizontal > 0 && !m_FacingRight)
        {
            // ... flip the player.
             //Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontal < 0 && m_FacingRight)
        {
            // ... flip the player.
             //Flip();
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
