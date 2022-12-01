using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Enemy", menuName = "Game_Jam_Novembre_2022/Enemy", order = 1)]
public class Enemy : ScriptableObject{

    public EnemyType _enemyType;
    public enum EnemyType
    {
        Spitter,
        Blaster,
    }

    public new string name;
    public string description;

    public GameObject bulletPrefab;

    public GameObject sprite;
    public int xSpawnPoint;
    public int ySpawnPoint;

    public int damage;
    public int health;
    public int fireRateo;

  
    // public Sprite GetSpriteOn()
    // {
    //     switch (_weaponType)
    //     {
    //         default:
    //         case WeaponType.Gun: return ItemAssets.Instance._gunSpriteOn;
    //         case WeaponType.Rifle: return ItemAssets.Instance._rifleSpriteOn;
    //         case WeaponType.Shotgun: return ItemAssets.Instance._shotgunSpriteOn;
    //         case WeaponType.Sniper: return ItemAssets.Instance._sniperSpriteOn;
    //         case WeaponType.RPG: return ItemAssets.Instance._rpgSpriteOn;
    //         case WeaponType.Potion: return ItemAssets.Instance._potionSpriteOn;
    //     }
    // }

    // public Sprite GetSpriteOff()
    // {
    //     switch (_weaponType)
    //     {
    //         default:
    //         case WeaponType.Gun: return ItemAssets.Instance._gunSpriteOff;
    //         case WeaponType.Rifle: return ItemAssets.Instance._rifleSpriteOff;
    //         case WeaponType.Shotgun: return ItemAssets.Instance._shotgunSpriteOff;
    //         case WeaponType.Sniper: return ItemAssets.Instance._sniperSpriteOff;
    //         case WeaponType.RPG: return ItemAssets.Instance._rpgSpriteOff;
    //         case WeaponType.Potion: return ItemAssets.Instance._potionSpriteOff;
    //     }
    // }
}