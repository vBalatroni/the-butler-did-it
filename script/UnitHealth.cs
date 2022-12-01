using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UnitHealth {
    int _currentHealth;
    int _currentMaxHealth;
    private int _minHealth;
    
    public int Health 
    {
        get { return _currentHealth; }
        set {_currentHealth = value; }

    }

    public int MaxHealth 
    {

        get { return _currentMaxHealth; }
        set { _currentMaxHealth = value; }

    }

    public int MinHealth 
    {
        get { return _minHealth; }
        set { _minHealth = value; }
    }

    public UnitHealth(int health, int maxHealth, int minHealth) 
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
        _minHealth = minHealth;
    }

    public void DmgUnit(int dmgAmount) 
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth -= dmgAmount;
            if (_currentHealth < 0) _currentHealth = 0;
        }
    }

    public void HealUnit(int healAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }
        if (_currentHealth > _currentMaxHealth) 
        {
            _currentHealth = _currentMaxHealth;
        }
    }
    
}
