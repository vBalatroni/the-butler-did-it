using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class genericButton : MonoBehaviour
{
    public UnityEvent evento;
    //public GameObject oggetto;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (evento != null) evento.Invoke();
    }
}
