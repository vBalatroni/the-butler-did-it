using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport target;
    //public Vector3 offset = Vector3.up;
    public Rigidbody2D player;
    //public ParticleSystem particellare;

    bool justTeleported = false;
    //public bool stop;

    //public AudioSource suonoTeletrasporto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!justTeleported)
        {
            target.justTeleported = true;
            //player.enabled = false;
            player.transform.position = target.transform.position /* + target.offset*/;
            


            /*if (player.enabled==false)
            {
                player.enabled = true;
            }*/

            //Suono del teletrasporto
            //target.suonoTeletrasporto.Play();
            //target.particellare.Play();
        }
        else
        {
            justTeleported = false;
        }

        /*Debug.Log("ciao");
        player.enabled = false;
        player.transform.position = target.transform.position + target.offset;
        
        if (player.enabled== false)
        {
            player.enabled = true;
        }*/
    }
}
