// using Cinemachine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class Moneta : MonoBehaviour
// {
//     public int valore;

//     public Animator animatore;
//     public AudioSource suono;
//     public float tempoDistruzione = 2f;
//     public GameObject effettoDistruzione;
//     public SphereCollider trigger;

//     public void MonetaRaccolta()
//     {

//         Debug.Log("moneta raccolta");

//         //METODI PER PARLARE CON IL GAME MANAGER PER LA SCENA
//         /* OPZIONE 1: cerco il game manager sulla base del tipo. Uso questo metodo solo se l'oggetto è univoco
//          * questo metodo è ottimale per i progetti piccoli, quando ci sono pochi oggetti in scena
//          */
//         //GameManager gameManager = FindObjectOfType<GameManager>();

//         /*OPZIONE 2: uso il singleton per arrivare subito al game manager
//          questa opzione è utile per quando ci sono molti oggetti in scena (i progetti professionali)*/
//         GameManager gameManager = GameManager.gameManager;

//         gameManager.RaccoltoOggetto(this);


//         /* il metodo Destroy() distrugge dalla scena l'oggetto indicato (lo elimina e il gioco pesa meno) e il secondo argomento è il tempo espresso in secondi */
//         Destroy(gameObject, tempoDistruzione);

//         GameObject nuovoOggetto;

//         /* il metodo Instanziate() crea una copia dell'oggetto che gli viene passato */
//         nuovoOggetto = Instantiate(effettoDistruzione);

//         // metto l'effetto particellare nella stessa posizione della moneta
//         nuovoOggetto.transform.position = this.transform.position;
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (trigger.enabled == true)
//         {
//             trigger.enabled = false;
//         }
//         animatore.SetTrigger("raccolta");
//         suono.Play();
//         MonetaRaccolta();
//     }
// }
