using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spon : MonoBehaviour
{
    public GameObject Coin100, Coin10, Coin1;
    public int money;
    public Vector3 place;
    void Start()
    {
        StartCoroutine(getCoin());
    }
    public void click()
    {
    StartCoroutine(getCoin());
    }

    public void updatamoney(int x) {
        money += x;
    }

    IEnumerator getCoin()
    {
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
