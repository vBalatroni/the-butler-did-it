using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointRotation : MonoBehaviour
{
    public Weapon tier1Weapon;
    public Weapon tier2Weapon;
    public Weapon tier3Weapon;
    public Weapon tier4Weapon;
    public Weapon tier5Weapon;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public float offset;
    private SpriteRenderer spriteRender;

    Vector2 movement; //vettore di movimento
    Vector2 mousePos;
    public static Weapon playerCurrentWeapon;

    public Camera cam;

    // Update is called once per frame

    private void Start() {
        Debug.Log("aaaaaaacurrent weapon: " + WeaponDisplay.playerCurrentWeapon);
        spriteRender.sprite = WeaponDisplay.playerCurrentWeapon.sprite;

    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //salvare la posizione del muose sulla griglia pixel
        //convertire il risultato della griglia in posizione del mondo
        //infine imposto il valore del Vector2 con il valore della posizione del mouse

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);

        if (angle < 89 && angle > -89)
        {
            Debug.Log("facing right");
            spriteRender.flipY = false;
        }
        else
        {
            Debug.Log("facing left");
            spriteRender.flipY = true;
        }

        // transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);

        // transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);

    }

    void FixedUpdate()
    {
        
    }
}
