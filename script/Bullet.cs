using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float destructionTime = .4f;

    public int bulletDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Weapons");
        Destroy(effect, destructionTime);
        Destroy(gameObject);
        
    }
}
