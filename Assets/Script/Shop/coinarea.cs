using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinarea : MonoBehaviour
{
    public int getmoney=0;
    public GameObject ev;
    public List<Shop> shop;
    public Text gmoneyDisplay;


    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Money_1")
        {
            getmoney += 1;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Money_10")
        {
            getmoney += 10;
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Money_100")
        {
            getmoney += 100;
            Destroy(collider.gameObject);
        }
        Debug.Log(getmoney);
        gmoneyDisplay.text = "$" + getmoney;
    }

    public int FindItem(string x)
    {
        int number = -1;
        for (int a = 0; a < 6; a++)
        {
            if (shop[a].name == x)
            {
                number = a;
                break;
            }
            else number = -1;
        }
        gmoneyDisplay.text = "$" + getmoney;
        return number;

    }

    public void sell(string x) {
        int number= FindItem(x);
        
        if (number != -1) {
            if (getmoney >= shop[number].price)
            {
                getmoney -= shop[number].price;
                Debug.Log("You buy " + shop[number].name);
                ev.GetComponent<Inventory>().AddCoin(-shop[number].price);
                switch (shop[number].name) {
                    case "Arrow": ev.GetComponent<Inventory>().AddArrow(1); break;
                    case "Fire Arrow": ev.GetComponent<Inventory>().AddFireArrow(1); break;
                    case "Frezze Arrow": ev.GetComponent<Inventory>().AddFreezeArrow(1); break;
                    case "Teleport Arrow": ev.GetComponent<Inventory>().AddTpArrow(1); break;
                    case "Potion": ev.GetComponent<Inventory>().AddHealing(1); break;
                }
            }
            else Debug.Log("No money");

        }
        else Debug.Log("No that Item");
        gmoneyDisplay.text = "$" + getmoney;
    }

}
