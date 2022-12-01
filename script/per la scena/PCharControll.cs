using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PCharControll : MonoBehaviour
{
    public CharacterController controller;
    public float velocita = 7;
    public float gravita = 10;
    public float velocitaRotazione = 180;
    public Animator animatore;
    //public AudioSource passi;

    // Update is called once per frame
    void Update()
    {

        /*recupera l'intenzione dell'utente di andare in avanti. Leggerà le informazioni
        del gamepad, wasd e frecce.
        ritorna un valore compreso tra -1 e 1 (1=avanti, -1=indietro, 0=fermo)
        la direzione avanti è l'avanti  dell'oggetto che si sta muovendo*/
        float avanti = Input.GetAxis("Vertical"); //funziona sia con la freccia in su che con la w

        


        controller.Move(transform.forward * Time.deltaTime * avanti * velocita); // per controllare se funziona

        // Dato che il character controller non ha gravità, io devo imporlo
        controller.Move(Vector3.down * Time.deltaTime * gravita);

        //Il character controller non comanda le rotazioni, quindi devo usare le proprietà della transform
        float rotazione = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * Time.deltaTime * rotazione * velocitaRotazione);

        //animatore.SetFloat("avanti", avanti); //DA RIATTIVARE MI RACCOMANDO ANDREA

        //comunico all'animatore se sto correndo o no
        //animatore.SetBool("camminando", avanti> 0.1f); Uso questo se voglio dare un valore booleano
        //animatore.SetFloat("avanti", avanti); // in questo caso uso un numero float

        /*if (controller.velocity.magnitude > 0)
        {
            if (!passi.isPlaying)
                passi.Play();
        }
        else
        {
            passi.Stop();
        }*/
    }
}