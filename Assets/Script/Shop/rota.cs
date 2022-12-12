using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rota : MonoBehaviour
{
    public GameObject things;
    void Update()
    {
        things.transform.Rotate(Vector3.up*15.0f*Time.deltaTime);
    }
}
