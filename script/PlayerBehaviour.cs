using System.Collections;
using System.Collections.Generic;
using Regex = System.Text.RegularExpressions.Regex;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Inventory _inventory;
    public SpriteList _healthBar;
    private UnitHealth _playerHealth;
    public Animator deathAnimator;
    public Rigidbody2D player;
    void Start()
    {
        _inventory = new Inventory();
        
        UIManager._uiManager.SetInventory(_inventory);
        UIManager._uiManager.RefreshBoxCurrentWeapon(5);
        UIManager._uiManager.RemoveChain(5);
        UIManager._uiManager.RemoveChain(0);

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.collider);
        if (collision.gameObject.tag == "EnemyProjectile" || collision.gameObject.tag == "Enemy" ) {
            Debug.Log("ON COLLISION PARENT: "  + collision.gameObject);
            int dmg = collision.gameObject.GetComponent<Projectile>().damageAmount;

            PlayerTakeDmg(dmg);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            PlayerTakeDmg(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerHeal(1);
        }

        if (PlayerIsDead())
        {
            GameManager.gameManager.Morte(deathAnimator);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (GameManager.gameManager._inventory.potion.currentHolderSize > 0 && GameManager.gameManager._playerHealth.Health < 5)
            {
                PlayerHeal(1);
                GameManager.gameManager._inventory.potion.currentHolderSize -= 1;
                UIManager._uiManager.UpdateAmmosCounter(GameManager.gameManager._inventory.potion.order, -1);

            }
        }
    }

    private void PlayerTakeDmg(int dmg) 
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
        _healthBar.UpdateHealthBar(GameManager.gameManager._playerHealth.Health);
    
    }

    private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
        _healthBar.UpdateHealthBar(GameManager.gameManager._playerHealth.Health);
    }

    
    private bool PlayerIsDead() 
    {
        // Debug.Log("health: " + GameManager.gameManager._playerHealth.Health);
        // Debug.Log("min health: " + GameManager.gameManager._playerHealth.MinHealth);

        if (GameManager.gameManager._playerHealth.Health == GameManager.gameManager._playerHealth.MinHealth) {
            return true;
        }
        else {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GroundItem") {
            collision.GetComponent<GroundItem>().HandleCollision(collision.GetComponent<GroundItem>()._itemType, collision.GetComponent<GroundItem>()._weaponType);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "EnemyWave") {
            string number = Regex.Match(collision.gameObject.name, @"\d+").Value;
            string toFind = "/LEVELS/level1/triggers/enemies" + number;
            // Debug.Log("TO FIND" + toFind);
            GameObject wave = GameObject.Find(toFind);
            // Debug.Log(" found" + wave);
            wave.SetActive(true);
        }
        

    }

    public Inventory PlayerInventory() {
        return _inventory;
    }
}
