using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public float bowPower = 50f;

    public Transform holdStringObjectOrigin;
    public Transform holdStringObject;
    public Arrow arrow;

    public GameObject[] arrowPrefab;

    public bool holdingString = false;
    public bool releaseString = false;

    public Transform player;
    public Inventory inventory;

    
    void Start() { SetArrow(); }

    void Update()
    {
        if (holdStringObjectOrigin.childCount <= 0 && !holdingString) { holdingString = true; }

        if (holdStringObjectOrigin.childCount > 0 && holdingString) { holdingString = false; ReleaseString(); }
    }


    // PURPOSE: Set Arrow as child of the "holdStringObject",reset pos of it.
    public void SetArrow()
    {
        if (arrow != null)
            Destroy(arrow.gameObject);

        arrow = inventory.GetArrow(GameUI1.selectedArrowType);
        if (arrow != null)
        {
            arrow.transform.SetParent(holdStringObject);
            arrow.transform.localPosition = new Vector3(0, 0, 4f);
            arrow.transform.localRotation = new Quaternion(0, 0, 0, 0);
            if (arrow.arrowType == Arrow.ArrowType.Teleport)
                arrow.teleportPlayer = player;
        }
    }

    // PURPOSE: Release arrow from "holdStringObject" parenting, calculate velocity & 
    // PURPOSE: apply arrow.Shot()v*Power. Finally reset the holdStringObject.
    void ReleaseString()
    {
        

        //cal arrow speed and send to arrow
        if (arrow != null)
        {
            arrow.transform.SetParent(null);
            Vector3 velocity = transform.position - holdStringObjectOrigin.position;
            velocity.Normalize();
            velocity *= Vector3.Distance(holdStringObjectOrigin.position, holdStringObject.position);
            arrow.Shot(velocity* bowPower);
            
            inventory.arrowCount[GameUI1.selectedArrowType] -= 1;
            arrow = null;
        }


        //string movement
        releaseString = true;
        holdStringObject.localPosition = Vector3.zero;
        holdStringObject.localRotation = Quaternion.identity;

        SetArrow();
    }
}
