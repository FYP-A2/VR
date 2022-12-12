using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform holdStringObjectOrigin;
    public Transform holdStringObject;
    public Arrow arrow;

    public GameObject[] arrowPrefab;

    public bool holdingString = false;
    public bool releaseString = false;

    public Transform player;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        SetArrow();
    }

    // Update is called once per frame
    void Update()
    {
        if (holdStringObjectOrigin.childCount <= 0 && !holdingString)
        {
            holdingString = true;
        }


        if (holdStringObjectOrigin.childCount > 0 && holdingString)
        {
            holdingString = false;
            ReleaseString();
        }

        //if (releaseString)

        


    }

    public void SetArrow()
    {
        if (arrow != null)
            Destroy(arrow.gameObject);
        Debug.Log(GameUI1.selectedArrowType);
        arrow = inventory.GetArrow(GameUI1.selectedArrowType);
        Debug.Log("bow arrow" + (arrow != null));
        Debug.Log("holdStringObject" + (holdStringObject != null));
        arrow.transform.SetParent(holdStringObject);
        arrow.transform.localPosition = new Vector3 (0, 0, 4f);
        arrow.transform.localRotation = new Quaternion (0, 0, 0, 0);
        if (arrow.arrowType == Arrow.ArrowType.Teleport)
            arrow.teleportPlayer = player;
    }


    void ReleaseString()
    {
        

        //cal arrow speed and send to arrow
        if (arrow != null)
        {
            arrow.transform.SetParent(null);
            Vector3 velocity = transform.position - holdStringObjectOrigin.position;
            velocity.Normalize();
            velocity *= Vector3.Distance(holdStringObjectOrigin.position, holdStringObject.position);
            arrow.Shot(velocity*30);
            
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
