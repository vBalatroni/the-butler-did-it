using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Game_Jam_Novembre_2022/Weapon", order = 0)]
public class Weapon : ScriptableObject {

    public WeaponType _weaponType;
    public int _amount;

    public int order;
    public enum WeaponType
    {
        Gun,
        Rifle,
        Shotgun,
        Sniper,
        RPG,
        Potion
    }
    public new string name;
    public string description;
    public Sprite sprite;

    public GameObject bulletPrefab;

    public Sprite ammosHolderSprite;
    public int ammosHolderSize;

    public int currentHolderSize;
    public float fireRateo;
    public int bulletDamage;
    public int weight;

    public int initial_ammo;

    
    public Sprite GetSpriteOn()
    {
        switch (_weaponType)
        {
            default:
            case WeaponType.Gun: return ItemAssets.Instance._gunSpriteOn;
            case WeaponType.Rifle: return ItemAssets.Instance._rifleSpriteOn;
            case WeaponType.Shotgun: return ItemAssets.Instance._shotgunSpriteOn;
            case WeaponType.Sniper: return ItemAssets.Instance._sniperSpriteOn;
            case WeaponType.RPG: return ItemAssets.Instance._rpgSpriteOn;
            case WeaponType.Potion: return ItemAssets.Instance._potionSpriteOn;
        }
    }

    public Sprite GetSpriteOff()
    {
        switch (_weaponType)
        {
            default:
            case WeaponType.Gun: return ItemAssets.Instance._gunSpriteOff;
            case WeaponType.Rifle: return ItemAssets.Instance._rifleSpriteOff;
            case WeaponType.Shotgun: return ItemAssets.Instance._shotgunSpriteOff;
            case WeaponType.Sniper: return ItemAssets.Instance._sniperSpriteOff;
            case WeaponType.RPG: return ItemAssets.Instance._rpgSpriteOff;
            case WeaponType.Potion: return ItemAssets.Instance._potionSpriteOff;
        }
    }
}