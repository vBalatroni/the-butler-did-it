using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponDisplay : MonoBehaviour
{
    float xInput = 0, yInput = 0;

    public GameObject player;
    public Transform gunSprite, gunTip; //credo il firepoint
    int playerSortingOrder = 20;
    Vector3 mousePos, mouseVector;
    bool mouseLeft, canShoot;

    


    public SpriteRenderer gunRend;

    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Camera cam;

    private SpriteRenderer spriteRender;

    Vector2 movement; //vettore di movimento

    private GameObject _weapon;
    private Vector3 _rotationVector = new Vector3(0, 0, 0);

    public static Weapon playerCurrentWeapon;

    // Start is called before the first frame update

    public Image weaponArtwork;  // cambia con sprite cos� posso sitemare su unity

    void Start()
    {
        
        GetMouseInput();
        _weapon = GameObject.Find("Weapon");
        // spriteRender.sprite = tier1Weapon.sprite;
        _weapon.transform.position = player.transform.position + new Vector3(0.074f,-0.208f,0);
        playerCurrentWeapon = GameManager.gameManager._inventory.tier1Weapon;
        // Debug.Log("weapon: " + weaponArtwork);
        // Debug.Log(weaponArtwork);
        Debug.Log("Current Weapon" + getCurrentWeapon().name);
        weaponArtwork.sprite = getCurrentWeapon().sprite;
        weaponArtwork.transform.rotation = Quaternion.Euler(_rotationVector);
        

    }

    void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical"); //capture wasd and arrow controls
        GetMouseInput();
    }
    public Weapon getCurrentWeapon()
    {
        return playerCurrentWeapon;
    }

    private void logWeapon() {
        foreach (KeyValuePair<Weapon, Weapon> weapon in GameManager.gameManager._inventory.GetItemList())
        {

            Debug.Log("KEY: " + weapon.Key + " - VALUE: " + weapon.Value.name);

        }
    }
    
    public Weapon setCurrentWeapon(Weapon weapon)
    {
        if (!weapon)
        {
            playerCurrentWeapon = new Weapon();
            return playerCurrentWeapon;
        }
        else return playerCurrentWeapon = weapon;
    }
        

    public void changeDisplayWeapon()
    {
        gunRend.sprite = getCurrentWeapon().sprite;
    }


    void FixedUpdate() {
        Animation();
        changeDisplayWeapon();
    }
    void Update()
    {
        GetInput();
        // Debug.Log(player.transform.position);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("key 1 pressed");
            Debug.Log(GameManager.gameManager._inventory.tier1Weapon._amount);
            if (GameManager.gameManager._inventory.tier1Weapon._amount > 0) {
                setCurrentWeapon(GameManager.gameManager._inventory.tier1Weapon);
                UIManager._uiManager.RefreshBoxCurrentWeapon(5);
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("key 2 pressed");
            Debug.Log(GameManager.gameManager._inventory.tier2Weapon._amount);

            if (GameManager.gameManager._inventory.tier2Weapon._amount > 0){
                setCurrentWeapon(GameManager.gameManager._inventory.tier2Weapon);
                UIManager._uiManager.RefreshBoxCurrentWeapon(4);
            }
            
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("key 3 pressed");
            Debug.Log(GameManager.gameManager._inventory.tier3Weapon._amount);

            if (GameManager.gameManager._inventory.tier3Weapon._amount > 0)
            {
                setCurrentWeapon(GameManager.gameManager._inventory.tier3Weapon);
                UIManager._uiManager.RefreshBoxCurrentWeapon(3);
            }
            

        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("key 4 pressed");
            if (GameManager.gameManager._inventory.tier4Weapon._amount > 0)
            {
                setCurrentWeapon(GameManager.gameManager._inventory.tier4Weapon);
                UIManager._uiManager.RefreshBoxCurrentWeapon(2);
            }
            

        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("key 5 pressed");
            if (GameManager.gameManager._inventory.tier5Weapon._amount > 0)
            {
                setCurrentWeapon(GameManager.gameManager._inventory.tier5Weapon);
                UIManager._uiManager.RefreshBoxCurrentWeapon(1);
            }
        }


        

        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition) ; //salvare la posizione del muose sulla griglia pixel
        // //convertire il risultato della griglia in posizione del mondo
        // //infine imposto il valore del Vector2 con il valore della posizione del mouse

        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Vector2 lookDir = mousePos - rb.position;
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        // rb.rotation = angle;
        // transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // if (angle < 89 && angle > -89)
        // {
        //     Debug.Log("facing right");
        //     rb.rotation = angle;
        //     weaponArtwork.transform.rotation = Quaternion.Euler(0, 0, angle);
        // }   
        // else
        // {
        //     Debug.Log("facing left");
        //     rb.rotation = angle;
        //     weaponArtwork.transform.rotation =  Quaternion.Euler(0, 180f, -angle + 180f);

        // }

    }

    void GetMouseInput()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //position of cursor in world
        mousePos.z = transform.position.z; //keep the z position consistant, since we're in 2d
        mouseVector = (mousePos - transform.position).normalized; //normalized vector from player pointing to cursor
        mouseLeft = Input.GetMouseButton(0); //check left mouse button
    }

    void Animation()
    {
        float gunAngle = -1 * Mathf.Atan2(mouseVector.y, mouseVector.x) * Mathf.Rad2Deg; //find angle in degrees from player to cursor
        gunSprite.rotation = Quaternion.AngleAxis(gunAngle, Vector3.back); //rotate gun sprite around that angle
        gunRend.sortingOrder = playerSortingOrder - 1; //put the gun sprite bellow the player sprite

        if (gunAngle > -45 || gunAngle < -135)
        { //put the gun on top of player if it's at the correct angle
            gunRend.sortingOrder = playerSortingOrder + 1;
            // Flip();

        }
        if (gunAngle < 90 && gunAngle > -90)
        {
            
            // Debug.Log("facing right");
            gunSprite.transform.rotation = Quaternion.Euler(0, 0, -gunAngle);
            player.transform.localScale= new Vector3(1, 1, 1);
            _weapon.transform.position = player.transform.position + new Vector3(1f,-0.2f,0);

        }   
    

        else
        {   
            // Debug.Log("facing left");
            gunSprite.transform.rotation =  Quaternion.Euler(0, 180f, gunAngle + 180f);
            player.transform.localScale= new Vector3(-1, 1, 1);
            _weapon.transform.position = player.transform.position + new Vector3(-8f,-0.2f,0);


        }
    }



    // private void Flip()
    // {
    //     // Multiply the player's x local scale by -1.
    //     Vector3 theScale = transform.localScale;
    //     theScale.x *= -1;
    //     transform.localScale = theScale;
    // }
}
