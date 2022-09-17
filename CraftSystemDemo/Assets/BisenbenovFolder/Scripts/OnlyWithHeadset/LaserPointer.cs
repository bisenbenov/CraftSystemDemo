using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean addInInventoryAction;

    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;
    private Vector3 hitPoint;

    // private bool shouldAddItem;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (addInInventoryAction.GetState(handType))
        {
            RaycastHit hit;

            //if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            //{
            //    hitPoint = hit.point;
            //    ShowLaser(hit);
            //}

            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);

                // shouldAddItem = true;

                var interatableObject = hit.collider.GetComponent<ItemPickup>();

                if (interatableObject != null)
                {
                    Inventory.instance.Add(interatableObject.item);
                }
            }

        }

        else
        {
            laser.SetActive(false);
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);

        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);

        laserTransform.LookAt(hitPoint);

        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
}
