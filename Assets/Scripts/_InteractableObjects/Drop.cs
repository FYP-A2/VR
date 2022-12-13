using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{    
    [SerializeField]GameObject coin;
    [SerializeField]GameObject mineral;
    Vector3 position;

    public void DropLoot()
    {
        position = new Vector3(transform.position.x,transform.position.y+2f,transform.position.z);
        coin = Instantiate(coin, position, Quaternion.identity);
        //if(Random.Range(0,100f) < 50)
        //{
        //    mineral = Instantiate(mineral, position, Quaternion.identity);
        //}
    }
}
