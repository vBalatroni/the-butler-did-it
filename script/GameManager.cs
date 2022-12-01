using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    /* Questa variabile esisterà una sola volta in memoria, sarà accessibile da tutti
     nella forma GameManager.instanza*/
    public static GameManager gameManager { get; private set;}
    // public CharacterController player;
    // public GameObject cameraFinale;

    // //collegamento con il testo della UI;
    // public Text uiValoreRaccolto;

    // /* Tiene traccia di quanto ho racolto fino ad ora. È sul GameManager perché è univoco in scena */
    // int valoreAttuale = 0;

    // [Header("obiettivi")]
    // /* È il valore dell'obiettivo, può essere cambiato da livello a livello in base alla scena */
    // public int valoreObiettivo = 15;
    // public int valoreFinale;
    // public GameObject percorsoFinale;
    // public GameObject pannelloVittoria;

    // [Header("morte")]
    // public float urloMorte;
    // public float morte;
    // public AudioSource suonoMorte;
    
    public UnitHealth _playerHealth = new UnitHealth(5, 5, 0);
    public AmmosHolder _playerAmmos = new AmmosHolder(50, 500);
    public Inventory _inventory;

    public AudioSource suono_morte;
    
    [Header("pausa")]
    public GameObject pannelloPausa;

    [Header("morte")]
    public GameObject pannelloMorte;

    private void Awake()
    {
        Time.timeScale = 1;
        //in questa variabile accessibile a tutti registro me stesso
        //chiunque può sapere chi sono
        //questo sostema si chiama SINGLETON
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Start()
    {
        // uiValoreRaccolto.text = "0";
    }

    // public void Urlo()
    // {
    //     if(player.transform.position.y <= urloMorte)
    //     {
    //         suonoMorte.Play();
    //     }
    // }

     private void Update()
     {
    //     Urlo();
    //     //controllo che il giocatore non vada troppo in basso
    //     if (player.transform.position.y < morte)
    //     {
    //         RipetiScena();
    //     }


         //se premo il pulsante pausa (esc, option) attivo il pannello pausa
         if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button7))
         {
             Pausa();
         }
         else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button7)))
         {
             RiprendiGioco();
         }

     }

    // Il Moneta che passo dentro al metodo RaccoltoOggetto è lo script creato "Moneta" e dato che è pubblico può essere richiamato da tutti
    // public void RaccoltoOggetto(Moneta oggettoRaccolto)
    // {
    //     //il "valore" è la variabile creata nello script "Moneta"
    //     //Aumento il valore attuale
    //     valoreAttuale =valoreAttuale + oggettoRaccolto.valore;
    //     Debug.LogFormat("Valore attuale: {0}", valoreAttuale);
    //     /* Scrive il valore attuale nella UI, ho usato il ToString() perché VAloreAttuale è un numero mentre uiValoreRaccolto è una stringa.
    //      * Per questo motivo ho dovuto convertire il numero intero in una stringa*/
    //     uiValoreRaccolto.text = valoreAttuale.ToString();

    //     //Controllo se ho vinto
    //     if (valoreAttuale >= valoreObiettivo)
    //     {
    //         percorsoFinale.SetActive(true);
    //     }
        
    //     if (valoreAttuale>=valoreFinale)
    //     {
    //         pannelloVittoria.SetActive(true);
    //         player.enabled = false;
    //         cameraFinale.SetActive(true);

    //         //modifica lo scorrere del tempo. Con lo zero fermo il mondo
    //         Time.timeScale = 0;
            
    //     }
    // }

    public void RiprendiGioco()
    {
        pannelloPausa.SetActive(false);
         //ferma il tempo
        Time.timeScale = 1;
        //ripristina il suono
         AudioListener.volume = 1;
    }

     // ricarica la scena che gli viene passata. La scena è quella salvata nella cartella di progetto
    public void RipetiScena()
    {
         //RiprendiGioco();
         SceneManager.LoadScene("Game");
         Time.timeScale = 1;
    }

    public void TornaAlMenu()
     {
         RiprendiGioco();
         SceneManager.LoadScene("mainMenu");
     }

    public void Pausa()
    {
         pannelloPausa.SetActive(true);
         //ferma il tempo
         Time.timeScale = 0;
         //ferma il suono
         AudioListener.volume = 0;
    }


    public void Morte(Animator animator)
    {
        GameObject.Find("Weapon").SetActive(false);
        // arma.SetActive(false);
        pannelloMorte.SetActive(true);
        //ANDREA CONTINUA QUI TU
        Time.timeScale = 0;
        animator.SetBool("morte", true);

        suono_morte.Play();
    }

}