using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class distruzione : MonoBehaviour
{
    public GameObject oggettoDaDistruggere;

    public float tempoDistruzione;

    public GameObject staiFermo;

    public Animator animator;

    private int _entityHealth;

    private int _bulletDamage;

    public AudioSource enemy_death;

    public void DestryComponent()
    {
        foreach (var comp in gameObject.GetComponents<Component>())
        {
            if (!(comp is Transform))
            {
                Destroy(comp);
            }
        }

        enemy_death.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            _entityHealth = gameObject.GetComponent<SpitterAttack>().entityHealth;
            _bulletDamage = collision.gameObject.GetComponent<Bullet>().bulletDamage;
        if (collision.gameObject.tag == "PlayerProjectile")
        {
        
            // Debug.Log("Player DMG: " + _bulletDamage);
            // Debug.Log("ENTITY Health:  " + _entityHealth);

            _entityHealth = gameObject.GetComponent<SpitterAttack>().UpdateHealth(_bulletDamage);

            if (_entityHealth <= 0)
            {
                DestryComponent();
                SpitterAttack scriptDaDisattivare = GetComponent<SpitterAttack>();
                scriptDaDisattivare.enabled = false;
                Destroy(oggettoDaDistruggere, tempoDistruzione);
                staiFermo.transform.position = new Vector2(oggettoDaDistruggere.transform.position.x, oggettoDaDistruggere.transform.position.y);
                animator.SetBool("morte", true);
            }
            
        }
        
    }
}