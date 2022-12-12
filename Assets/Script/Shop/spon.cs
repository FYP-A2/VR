using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spon : MonoBehaviour
{
    public GameObject Coin100, Coin10, Coin1,even,ev;
    public List<GameObject> Coin;
    public int money;
    public Vector3 place;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            StartCoroutine(getCoin());
            ev.GetComponent<coinarea>().getmoney=0;

            Debug.Log("enter shop");
        }
        if (collider.gameObject.tag == "Money_1")
        {
            Coin.Add(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Money_10")
        {
            Coin.Add(collider.gameObject);
        }
        else if (collider.gameObject.tag == "Money_100")
        {
            Coin.Add(collider.gameObject);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
            ClearCoin();
    }

    public void ClearCoin() {
        GameObject[] gameObjects = null;
        Coin.CopyTo(gameObjects);
        Coin.Clear();
        foreach (GameObject co in gameObjects)
        {
            if (co != null)
                Destroy(co);
        }
    }


    IEnumerator getCoin()
    {
        money = even.GetComponent<Inventory>().coins;
        Debug.Log("money "+ money);
        for (int x=0;x<10;x++) {
            if (money >= 1)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 1;
                GameObject Coins = Instantiate(Coin1, new Vector3(place.x, place.y+3f, place.z), Coin1.transform.rotation);
     
            }
        }
        for (int x = 0; x < 10; x++)
        {
            if (money >= 10)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 10;
                GameObject Coins = Instantiate(Coin10, new Vector3(place.x, place.y + 3f, place.z), Coin10.transform.rotation);
                
            }
        }
        Debug.Log(money);
        do
        {
            if (money >= 100)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 100;
                GameObject Coins = Instantiate(Coin100, new Vector3(place.x, place.y + 3f, place.z), Coin100.transform.rotation);
                
 
            }
            else if (money >= 10)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 10;
                GameObject Coins = Instantiate(Coin10, new Vector3(place.x, place.y + 3f, place.z), Coin10.transform.rotation);

            }
            else if (money >= 1)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 1;
                GameObject Coins = Instantiate(Coin1, new Vector3(place.x, place.y + 3f, place.z), Coin1.transform.rotation);

            }
          //  Debug.Log(money);
        } while (money > 0);
    }

    void Update() {
            
           

    }

}
