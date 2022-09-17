using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class LaserButtonClicker : MonoBehaviour
{
    public InteractableForScene focus;

    public Hand hand;

    //Camera cam;

    //public Player player;

    //public PlayerController playerController;

    public SteamVR_Input_Sources myHand;
    public SteamVR_Action_Boolean interactAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("default", "InteractUI");
    private SteamVR_LaserPointer laserPointer;
    private GameObject btn; //should be an object to craft, i guess
    private bool pointerOnButton = false;
    void Start()
    {
        //playerController = player.GetComponent<PlayerController>();
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += LaserPointer_PointerIn;
        laserPointer.PointerOut += LaserPointer_PointerOut;
    }
    private void LaserPointer_PointerIn(object sender, PointerEventArgs e)
    {
        //if (e.target.gameObject.GetComponent<Button>() != null && btn == null)
        //{
        //    btn = e.target.gameObject;
        //    InputModule.instance.HoverBegin(btn);
        //    pointerOnButton = true;
        //}

        // Maybe it is
        if (e.target.gameObject.GetComponent<ItemPickup>() != null)
        {
            btn = e.target.gameObject;
            InputModule.instance.HoverBegin(btn);
            pointerOnButton = true;

            Inventory.instance.Add(e.target.gameObject.GetComponent<ItemPickup>().item);
        }
    }

    private void LaserPointer_PointerOut(object sender, PointerEventArgs e)
    {
        if (btn != null)
        {
            pointerOnButton = false;
            InputModule.instance.HoverBegin(btn);
            btn = null;
        }
    }

    void Update()
    {
        if (pointerOnButton)
        {
            if (interactAction[myHand].stateDown)
            {
                InputModule.instance.Submit(btn);
            }
        }
    }
}
