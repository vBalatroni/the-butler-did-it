using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIManager : MonoBehaviour
{

    public static UIManager _uiManager { get; set; }
    private Inventory _inventory;

    private Transform _itemSlotContainer;
    private Transform _itemSlotTemplate;

    // Start is called before the first frame update
    [SerializeField] public Text _currentAmmos;
    [SerializeField] public Text _ammosLeft;

    void Start()
    {
        _currentAmmos.text = "Ammos: " + GameManager.gameManager._playerAmmos.CurrentAmmmo;
        _ammosLeft.text = " / " + GameManager.gameManager._playerAmmos.AmmosLeft;

    }

    void Awake()
    {
        _uiManager = this;
        _itemSlotContainer = transform.Find("Inventory");
        _itemSlotTemplate = _itemSlotContainer.Find("Slot");
    }

    // Update is called once per frame
    void Update()
    {
        // LogWeapon();
    }

    public void updateCurrentAmmos(int currAmmos) 
    {
        _currentAmmos.text = "Ammos: " + currAmmos.ToString();
    }

    public void updateLeftAmmos(int leftAmmos)
    {
        _ammosLeft.text = " / " + leftAmmos.ToString();
    }

    public void SetInventory(Inventory inventory)
    {
        this._inventory = inventory;
        RefreshInventoryItems();
    }

    // private void LogWeapon() {
    //     foreach (KeyValuePair<Weapon, Weapon> weapon in _inventory.GetItemList())
    //     {

    //         Debug.Log("KEY: " + weapon.Key + " - VALUE: " + weapon.Value.name);
            
    //     }
    // }   
    public void RefreshInventoryItems() 
    {   
        int x = 0;
        int y = 0;
        float offset = 179.5f;
        float itemSlotCellSize = 73f;
        Debug.Log("UI MANAGER: " + GameManager.gameManager._inventory.GetItemList().Count);
        foreach (KeyValuePair<Weapon, Weapon> weapon in GameManager.gameManager._inventory.GetItemList()) {
            
            RectTransform itemSlotRectTransform = Instantiate(_itemSlotTemplate, _itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            if (x == 0) {
                itemSlotRectTransform.anchoredPosition = new Vector2(-offset, 0);

            }
            else {
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize - offset, y * itemSlotCellSize);
            }
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            Image imageInactive = itemSlotRectTransform.Find("imageInactive").GetComponent<Image>();

            image.sprite = weapon.Value.GetSpriteOn();
            Text numberWeapon = itemSlotRectTransform.Find("KeyNumber/button").GetComponent<Text>();
            Text weaponAmmosCount = itemSlotRectTransform.Find("Ammos/counter").GetComponent<Text>();
            if (x!= 5)
            {
                Image weaponAmmosImage = itemSlotRectTransform.Find("Ammos/image").GetComponent<Image>();
                weaponAmmosImage.sprite = weapon.Value.ammosHolderSprite;
            }

            weaponAmmosCount.text = (weapon.Value.currentHolderSize).ToString();
            numberWeapon.text = (1 + x).ToString();
            imageInactive.sprite = weapon.Value.GetSpriteOff();
            // Debug.Log(image);

            if (x==5) 
            {   
                imageInactive.gameObject.SetActive(false);
                image.sprite = weapon.Value.GetSpriteOn();
            }

            
            x++;
            if (x > 6) {
                x = 0;
                y++;
            }
        }
    }


    public void RefreshBoxCurrentWeapon(int n) 
    {

        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Slot(Clone)");
        List<GameObject> inventoryObject = objects.ToList();

        int i = 0;
        inventoryObject.ForEach(delegate(GameObject slot) {
            
            if (i!= 0) {
                GameObject activeBorder = slot.transform.GetChild(1).gameObject;

                if (i != n) {
                    activeBorder.SetActive(true);
                }
                else {
                    activeBorder.SetActive(false);
                }
            }
            i++;
        });
        
    }

    public void RemoveChain(int n)
    {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Slot(Clone)");
        List<GameObject> inventoryObject = objects.ToList();

        

        inventoryObject[n].gameObject.transform.GetChild(3).gameObject.SetActive(false);
        inventoryObject[n].gameObject.transform.GetChild(4).gameObject.SetActive(false);

        if (n == 5)
        {
            Text text = inventoryObject[n].transform.Find("Ammos/counter").GetComponent<Text>();
            text.text = "∞";
        }
        
    }

    public void UpdateAmmosCounter(int n, int amount)
    {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "Slot(Clone)");
        List<GameObject> inventoryObject = objects.ToList();



        int currentAmmo = Convert.ToInt32(inventoryObject[n].transform.Find("Ammos/counter").GetComponent<Text>().text);

        //Debug.Log("CURRENT AMMO: " + currentAmmo);
        currentAmmo += amount;
        //Debug.Log("NEW AMMO: " + currentAmmo);

        Text text = inventoryObject[n].transform.Find("Ammos/counter").GetComponent<Text>();
        text.text = currentAmmo.ToString();

        // Debug.Log("e MO?: " +  text.text);


    }

   

 
}
