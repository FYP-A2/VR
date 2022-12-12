using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spon : MonoBehaviour
{
    public GameObject Coin100, Coin10, Coin1;
    public int money;
    void Start()
    {
        Debug.Log(money);
    }
    public void click()
    {
    StartCoroutine(getCoin());
    }

    public void updatamoney(int x) {
        money += x;
        Debug.Log(money);
    }

    IEnumerator getCoin()
    {
        for (int x=0;x<10;x++) {
            if (money >= 1)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 1;
                GameObject Coins = Instantiate(Coin1, new Vector3(Coin1.transform.position.x, Coin1.transform.position.y + 10f, Coin1.transform.position.z), Coin1.transform.rotation);
     
            }
        }
        for (int x = 0; x < 10; x++)
        {
            if (money >= 10)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 10;
                GameObject Coins = Instantiate(Coin10, new Vector3(Coin10.transform.position.x, Coin10.transform.position.y + 10f, Coin10.transform.position.z), Coin10.transform.rotation);
                
            }
        }
        Debug.Log(money);
        do
        {
            if (money >= 100)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 100;
                GameObject Coins = Instantiate(Coin100, new Vector3(Coin100.transform.position.x, Coin100.transform.position.y + 10f, Coin100.transform.position.z), Coin100.transform.rotation);
                
 
            }
            else if (money >= 10)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 10;
                GameObject Coins = Instantiate(Coin10, new Vector3(Coin10.transform.position.x, Coin10.transform.position.y + 10f, Coin10.transform.position.z), Coin10.transform.rotation);

            }
            else if (money >= 1)
            {
                yield return new WaitForSeconds(0.25f);
                money -= 1;
                GameObject Coins = Instantiate(Coin1, new Vector3(Coin1.transform.position.x, Coin1.transform.position.y + 10f, Coin1.transform.position.z), Coin1.transform.rotation);

            }
          //  Debug.Log(money);
        } while (money > 0);
    }

    void Update() {
            
           

    }

}
