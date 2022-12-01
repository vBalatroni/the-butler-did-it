using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private Dictionary<Weapon, Weapon> _weaponList;

    public Weapon tier1Weapon;
    public Weapon tier2Weapon;
    public Weapon tier3Weapon;
    public Weapon tier4Weapon;
    public Weapon tier5Weapon;
    public Weapon potion;
    
    public void Awake() {
        tier2Weapon._amount = 0;
        tier3Weapon._amount = 0;
        tier4Weapon._amount = 0;
        tier5Weapon._amount = 0;

        tier1Weapon.currentHolderSize = tier1Weapon.initial_ammo;
        tier2Weapon.currentHolderSize = tier2Weapon.initial_ammo;
        tier3Weapon.currentHolderSize = tier3Weapon.initial_ammo;
        tier4Weapon.currentHolderSize = tier4Weapon.initial_ammo;
        tier5Weapon.currentHolderSize = tier5Weapon.initial_ammo;
        potion.currentHolderSize = potion.ammosHolderSize;

        _weaponList = new Dictionary<Weapon, Weapon>();
        AddItem(new Weapon { _weaponType = Weapon.WeaponType.Gun, _amount = 0 }, tier1Weapon);
        AddItem(new Weapon { _weaponType = Weapon.WeaponType.Rifle, _amount = 0 }, tier2Weapon);
        AddItem(new Weapon { _weaponType = Weapon.WeaponType.Shotgun, _amount = 0 }, tier3Weapon);
        AddItem(new Weapon { _weaponType = Weapon.WeaponType.Sniper, _amount = 0 }, tier4Weapon);
        AddItem(new Weapon { _weaponType = Weapon.WeaponType.RPG, _amount = 0 }, tier5Weapon);
        AddItem(new Weapon { _weaponType = Weapon.WeaponType.Potion, _amount = 0 }, potion);

        // UIManager._uiManager.RemoveChain(0);
        // UIManager._uiManager.RemoveChain(5);

    }

    public void AddItem(Weapon inventoryWeapon, Weapon playerWeapon) {
        _weaponList.Add(inventoryWeapon, playerWeapon);
    }



    public Dictionary<Weapon, Weapon> GetItemList()
    {
        return _weaponList;
    }
}
