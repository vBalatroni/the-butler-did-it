using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }

    public Sprite _gunSpriteOn;
    public Sprite _rifleSpriteOn;
    public Sprite _shotgunSpriteOn;
    public Sprite _sniperSpriteOn;
    public Sprite _rpgSpriteOn;
    public Sprite _potionSpriteOn;

    public Sprite _gunSpriteOff;
    public Sprite _rifleSpriteOff;
    public Sprite _shotgunSpriteOff;
    public Sprite _sniperSpriteOff;
    public Sprite _rpgSpriteOff;
    public Sprite _potionSpriteOff;


}
