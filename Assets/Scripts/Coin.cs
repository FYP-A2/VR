using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    bool collected = false;
    // PURPOSE: When coin hit player, coin destroyed.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            other.transform.parent.GetComponent<Inventory>().AddCoin(Random.Range(1,6));
            GetComponent<AudioSource>().Play();
            Destroy(this.gameObject,2f);
            collected = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
