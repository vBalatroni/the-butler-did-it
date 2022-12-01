using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerDialogo : MonoBehaviour
{
    public UnityEvent eventoo;
    //public GameObject oggetto;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (eventoo != null) eventoo.Invoke();
    }
    
}