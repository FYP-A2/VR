using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinarea : MonoBehaviour
{
    int getmoney=0;
    public GameObject ev;
    public List<Shop> shop;


    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Money_1")
        {
            getmoney += 1;
            Destroy(collider.gameObject, 0);
        }
        else if (collider.gameObject.tag == "Money_100")
        {
            getmoney += 100;
            Destroy(collider.gameObject, 0);
        }
        else if (collider.gameObject.tag == "Money_10000")
        {
            getmoney += 10000;
            Destroy(collider.gameObject, 0);
        }
        Debug.Log(getmoney);
    }


    void OnCollisionStay(Collision collisionInfo)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
        }
    }




    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Money_1")
            getmoney -= 1;
        else if (collider.gameObject.tag == "Money_100")
            getmoney -= 100;
        else if (collider.gameObject.tag == "Money_10000")
            getmoney -= 10000;
        Debug.Log(getmoney);
    }

    public void sell(int x) {
        int number=-1;
        for (int y = 0; y < 6; y++)
        {
            if (shop[y].price == x)
            {
                number = y;
                break;
            }
            else number = -1;
        }
        if (number != -1) {
            if (getmoney >= shop[number].price)
            {
                getmoney -= shop[number].price;
                Debug.Log("You buy " + shop[number].name);
                Debug.Log(getmoney);
            }
            else Debug.Log("No money");

        }
        else Debug.Log("No that Item");
    }

    public void givebackmoney() {
        if (getmoney != 0)
        {
            ev.GetComponent<spon>().updatamoney(getmoney);
            Debug.Log("give back u "+ getmoney);
            getmoney = 0;
        }
        else Debug.Log("No money give back u");
        
    }


}