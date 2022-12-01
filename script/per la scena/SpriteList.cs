using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteList : MonoBehaviour
{
    public Sprite[] sprites;
    public Image immagine;


    public void UpdateHealthBar(int health) {
        immagine.sprite = sprites[health];
    }
}
