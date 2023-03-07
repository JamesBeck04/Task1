using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    Transform cameraTransform;
    float range = 100f;

    [SerializeField]
    float rawDamage = 10f;

    void Update()
    {
        FireWeapon();
    }

    void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1f)
        {
           
            Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, range))
            {
         
                if (raycastHit.transform != null)
                {
                    raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);

                }
            }
            else
            {
                Debug.Log("NO RAYCAST");
            }
        }
    }
}