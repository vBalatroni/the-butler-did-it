using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparare : MonoBehaviour
{
    public GameObject colpo;
    public  Vector3 velocitaColpo;
    public Vector3 offset;
    public GameObject player;
    public GameObject occhio;
    GameObject nuovoOggetto;

    public void sparatoria()
    {
        //GameObject nuovoOggetto;
        nuovoOggetto = Instantiate(colpo);
        nuovoOggetto.transform.position = occhio.transform.position + offset;
        //nuovoOggetto.transform.Translate(Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            sparatoria();
        }
    }
}
