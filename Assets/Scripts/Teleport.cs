using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject targetPoint;
    public SpawnManager spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            controller.enabled = false;
            Debug.Log(gameObject.name + "?" + targetPoint.name);
            player.transform.position = targetPoint.transform.position;
            controller.enabled = true;
            if (targetPoint.name.Equals("villageTP"))
                spawn.start = false;
            if (targetPoint.name.Equals("level1TP"))
                spawn.start = true;
        }
    }
}
