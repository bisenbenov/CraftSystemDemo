using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;

        // For Test 
        Debug.Log("Script awake");
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.GetComponent<ItemPickup>() != null)
        {
            
            // For Test 
            Debug.Log(e.target.name);
            //
            Inventory.instance.Add(e.target.GetComponent<ItemPickup>().item);
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {

    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {

    }
}