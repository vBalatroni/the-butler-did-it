using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;

    public GameObject firstWeaponPrefab;
    public GameObject secondWeaponPrefab;


    Vector2 movement; //vettore di movimento
    Vector2 mousePos;

    private float fireRate = 1f;
    private float nextFire = 0f;
    public float bulletforce = 20f;

    private CameraController script;

    public AudioSource suono_sparo;

    // Update is called once per frame

    void Start() {
        firePoint.rotation = Quaternion.Euler(0, 0, -90f);
    }


    void Update()
    {
        fireRate = WeaponDisplay.playerCurrentWeapon.fireRateo;
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            nextFire = 0;
        }


        
        if (Input.GetButtonDown("Fire1" ) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // if (GameManager.gameManager._playerAmmos.CurrentAmmmo > 0)
            // {
            //     Shoot(firstWeaponPrefab);
            //     GameManager.gameManager._playerAmmos.consumeAmmo(1);
                
            //     // script.Shake((transform.position - firePoint.position).normalized, 10f, 10f);
            // }
            if (WeaponDisplay.playerCurrentWeapon.currentHolderSize > 0)
            {
                Shoot(firstWeaponPrefab);
                suono_sparo.Play();
                WeaponDisplay.playerCurrentWeapon.currentHolderSize -= 1;
                UIManager._uiManager.UpdateAmmosCounter(WeaponDisplay.playerCurrentWeapon.order, -1);

                // script.Shake((transform.position - firePoint.position).normalized, 10f, 10f);
            }
        
        }

        // if (Input.GetButtonDown("Fire2"))
        // {
        //     if (GameManager.gameManager._playerAmmos.CurrentAmmmo > 0)
        //     {
        //         Shoot(secondWeaponPrefab);
        //         GameManager.gameManager._playerAmmos.consumeAmmo(1);
        //         Debug.Log(GameManager.gameManager._playerAmmos.AmmosLeft);
        //         //script.Shake((transform.position - firePoint.position).normalized, 1.5f, 0.05f);
        //     }
        // }

        
    }

    void Shoot(GameObject currentWeapon)
    {

        GameObject bullet = Instantiate(WeaponDisplay.playerCurrentWeapon.bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().bulletDamage = WeaponDisplay.playerCurrentWeapon.bulletDamage;
        bullet.layer = 8;
        bullet.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Weapons");

        //creo il proiettile tramite il prefab. Nella funzione Instantiate() al primo posto c'� cosa creare
        //al secondo posto il punto in cui prearlo e al terzo posto la rotazione dell'oggetto
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);

        
    }

}
