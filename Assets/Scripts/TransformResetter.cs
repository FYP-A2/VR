using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformResetter : MonoBehaviour
{
    bool itemLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0 && !itemLeft)
            itemLeft = true;


        if (transform.childCount > 0 && itemLeft)
        {
            Transform childTransform = transform.GetChild(0).gameObject.transform;
            childTransform.localPosition = Vector3.zero;
            childTransform.localRotation = Quaternion.identity;
            itemLeft = false;
        }

    }
}
