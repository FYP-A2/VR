using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mineral : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
