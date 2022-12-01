using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    //public float offset;

    private SpriteRenderer spriteRender;

    Vector2 movement; //vettore di movimento
    Vector2 mousePos;

    public Camera cam;

    private void Start() 
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //salvare la posizione del muose sulla griglia pixel
        //convertire il risultato della griglia in posizione del mondo
        //infine imposto il valore del Vector2 con il valore della posizione del mouse

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        /*Vector2 lookDir = mousePos - rb.position;
        //Vector3 lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        //transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);

        if(angle <= 89 && angle >= -89) 
        {
            Debug.Log("facing right");
            //spriteRender.flipY = false;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z); 
            
        }
        else 
        {
            Debug.Log("facing right");
            //spriteRender.flipY = true;
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }*/
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if(angle < 89 && angle > -89) 
        {
            Debug.Log("facing right");
            spriteRender.flipY = false;
        }
        else 
        {
            Debug.Log("facing left");
            spriteRender.flipY = true;
        }
    }
}