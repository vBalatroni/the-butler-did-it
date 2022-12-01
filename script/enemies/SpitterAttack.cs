using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitterAttack : MonoBehaviour
{

    public float speed;
    //public float stoppingDistance;
    //public float retreatDistance;

    public enum EnemyType
    {
        Spitter,
        Blaster
    }
    private float timeBtwShots;
    public float startTimeBtwShots;

    public int entityHealth;
    public int entityDamage;
    public GameObject projectile;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Enemy name: " + gameObject.name);
        /*if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }*/

        if (timeBtwShots <= 0) 
        {

           GameObject enemyBullet = Instantiate(projectile, transform.position, Quaternion.identity); // Quaternion.identity = non ruota
           GetScript(enemyBullet);
           timeBtwShots = startTimeBtwShots; //senza questo il nemico spara ogni frame
        }
        else 
        {
            timeBtwShots -= Time.deltaTime; //se timebtwshots =2, ci vogliono 2 secondi per farlo diventare =0
        }
    }

    public void GetScript(GameObject en)
    {
        Projectile pro = en.GetComponent<Projectile>();

        pro.parent = gameObject;
        pro.damageAmount = this.entityDamage;

        // Debug.Log("Parent projectile: " + pro.parent.name);
    }

    public int UpdateHealth(int amount) {
        return entityHealth -= amount;
    }
}
