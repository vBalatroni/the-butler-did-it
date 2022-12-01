using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class StartAnimation : MonoBehaviour
{
    float horizontal;
    float vertical;
    public Animator animatore;
    public Rigidbody2D player;
    public AudioSource suonoPassi;

    // Update is called once per frame
    void Update()
    {
        //dò un valore a horizontal e vertical
        float destra = horizontal = Input.GetAxisRaw("Horizontal");
        float giu = vertical = Input.GetAxisRaw("Vertical");

        animatore.SetFloat("giu", giu);
        animatore.SetFloat("sinistra", destra);

        if (player.velocity.magnitude > 0)
        {
            if (!suonoPassi.isPlaying)
                suonoPassi.Play();
        }
        else
        {
            suonoPassi.Stop();
        }
    }
}
