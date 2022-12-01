using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    // Start is called before the first frame update

    public ItemType _itemType;

    public WeaponType _weaponType;

    public enum ItemType
    {
        Weapon,
        Ammo,
        Potion
    }

    public enum WeaponType
    {
        Gun,
        Rifle,
        Shotgun,
        Sniper,
        RPG,
        Potion
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleCollision(ItemType itemType, WeaponType weaponType) {
        if (itemType == ItemType.Weapon) {
            // Debug.Log("Collider is weapon");
            switch (weaponType) 
            {
                default: 
                case WeaponType.Gun:
                    GameManager.gameManager._inventory.tier1Weapon._amount += 1;
                    UIManager._uiManager.RemoveChain(5);

                    break;
                case WeaponType.Rifle:
                    GameManager.gameManager._inventory.tier2Weapon._amount += 1;
                    UIManager._uiManager.RemoveChain(4);

                    break;
                case WeaponType.Shotgun:  
                    GameManager.gameManager._inventory.tier3Weapon._amount += 1;
                    UIManager._uiManager.RemoveChain(3);

                    break;
                case WeaponType.Sniper:
                    GameManager.gameManager._inventory.tier4Weapon._amount += 1;
                    UIManager._uiManager.RemoveChain(2);

                    break;

                case WeaponType.RPG:
                    GameManager.gameManager._inventory.tier5Weapon._amount += 1;
                    UIManager._uiManager.RemoveChain(1);
                    break;

            }
        }
        else if (itemType == ItemType.Ammo)
        {
            // Debug.Log("Collider is ammo");
            switch (weaponType)
            {
                default:
                case WeaponType.Gun:
                    //GameManager.gameManager._inventory.tier1Weapon.currentHolderSize += GameManager.gameManager._inventory.tier1Weapon.ammosHolderSize;
                    //UIManager._uiManager.UpdateAmmosCounter(5, GameManager.gameManager._inventory.tier1Weapon.ammosHolderSize);

                    break;
                case WeaponType.Rifle:
                    GameManager.gameManager._inventory.tier2Weapon.currentHolderSize += GameManager.gameManager._inventory.tier2Weapon.ammosHolderSize;
                    UIManager._uiManager.UpdateAmmosCounter(4, GameManager.gameManager._inventory.tier2Weapon.ammosHolderSize);

                    break;
                case WeaponType.Shotgun:
                    GameManager.gameManager._inventory.tier3Weapon.currentHolderSize += GameManager.gameManager._inventory.tier4Weapon.ammosHolderSize;
                    UIManager._uiManager.UpdateAmmosCounter(3, GameManager.gameManager._inventory.tier3Weapon.ammosHolderSize);

                    break;
                case WeaponType.Sniper:
                    GameManager.gameManager._inventory.tier4Weapon.currentHolderSize += GameManager.gameManager._inventory.tier4Weapon.ammosHolderSize;
                    UIManager._uiManager.UpdateAmmosCounter(2, GameManager.gameManager._inventory.tier4Weapon.ammosHolderSize);

                    break;

                case WeaponType.RPG:
                    GameManager.gameManager._inventory.tier5Weapon.currentHolderSize += GameManager.gameManager._inventory.tier5Weapon.ammosHolderSize;
                    UIManager._uiManager.UpdateAmmosCounter(1, GameManager.gameManager._inventory.tier5Weapon.ammosHolderSize);
                    break;

            }
        }
        else if (itemType == ItemType.Potion)
        {
            GameManager.gameManager._inventory.potion.currentHolderSize += 1;
            UIManager._uiManager.UpdateAmmosCounter(0, 1);
        }
    }
   
}
