using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // указать в текстовой версии способ проверки LaserPointer.cs или SceneHandler.cs

        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit))
            {
                var interatableObject = hit.collider.GetComponent<ItemPickup>();
        
                if (interatableObject != null)
                {
                    Inventory.instance.Add(interatableObject.item);
                }
            }
        }
    }
}
