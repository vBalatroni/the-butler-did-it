using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmosHolder
{
    private int _currentAmmos;
    private int _ammosLeft;

    private int _holderSize;
    public int CurrentAmmmo
    {
        get { return _currentAmmos; }
        set { _currentAmmos = value; }
    }

    public int AmmosLeft
    {
        get { return _ammosLeft; }
        set {_ammosLeft = value; }
    }
    
    public AmmosHolder(int currentAmmos, int ammosLeft) 
    {
        _currentAmmos = currentAmmos;
        _ammosLeft = ammosLeft;
        _holderSize = 50;
    }

    public void consumeAmmo(int consumedAmmo)
    {
        if (_currentAmmos > 0 && (_currentAmmos - consumedAmmo) >= 0 )
        {
            _currentAmmos -= consumedAmmo;
            UIManager._uiManager.updateCurrentAmmos(_currentAmmos);
        }
    }

    public void reloadAmmo() 
    {
        if (_ammosLeft > 0 && (_ammosLeft - _holderSize) >= 0 && _currentAmmos < _holderSize)
        {
            int diff = _holderSize - _currentAmmos;
            _currentAmmos += diff;
            _ammosLeft -= diff;
            UIManager._uiManager.updateCurrentAmmos(_currentAmmos);
            UIManager._uiManager.updateLeftAmmos(_ammosLeft);

        }
    }

    
}
