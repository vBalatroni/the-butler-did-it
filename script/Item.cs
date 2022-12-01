using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemType 
    {
        Weapon,
        Potion
    }

    public ItemType _itemType;
    public int _amount;

    // public Sprite GetSprite() 
    // {
    //     switch(_itemType) {
    //         default:
    //         case ItemType.Weapon: return ItemAssets.Instance._weaponSprite;
    //         case ItemType.Potion: return ItemAssets.Instance._potionSprite;
    //     }
    // }
}