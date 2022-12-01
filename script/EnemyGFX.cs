using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f) //se +, verso destra
        {
            transform.localScale = new Vector3(-60f, 60f, 0f);
        } else if (aiPath.desiredVelocity.x <= 0.01f) //se -, verso sinistra
        {
            transform.localScale = new Vector3(60f, 60f, 0f); //flip sprite
        }
    }
}
