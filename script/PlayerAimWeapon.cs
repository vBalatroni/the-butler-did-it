using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform aimTransform;

    private void Awake() {
        aimTransform = transform.Find("grafica/Weapon");
    }

    private void Update() {
        HandleAiming();
    }

    

    private void HandleAiming() {
        Vector3 mousePosition = GetMouseWorldPosition();
        
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

 


    //utils
    public static Vector3 GetMouseWorldPosition() {
        Debug.Log("CAMERA " + Camera.main);
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec. z = 0f;
        return vec;
    }
    
    public static Vector3 GetMouseWorldPositionWithZ() {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
    return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

}