using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    public bool shot = false;
    public float damage = 10;
    public enum ArrowType { Normal = 0, Teleport = 1, Fire = 2, Freeze = 3}
    public ArrowType arrowType = ArrowType.Normal;

    public Rigidbody rb;
    public Transform teleportPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HoldingArrow();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot(Vector3 velocity)
    {
        Debug.Log("arrow velo " + velocity);
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = velocity;
        //rb.AddForce(velocity);
        shot = true;
    }

    public void HoldingArrow()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
        shot = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Inside other: " + collision.gameObject.name);
        if (!shot) { return; }
        else if (collision.gameObject.tag == "Monster")
        {
            Monster m = collision.gameObject.GetComponent<Monster>();
            switch (arrowType)
            {
                case ArrowType.Normal:
                    m.TakeDamage((int)damage);
                    break;
                case ArrowType.Teleport:
                    teleportPlayer.transform.position = transform.position;
                    break;
                case ArrowType.Fire:
                    m.TakeFire((int)damage);
                    break;
                case ArrowType.Freeze:
                    m.TakeFreeze((int)damage);
                    break;
            }

            shot = false;

            transform.SetParent(collision.transform);
            rb.isKinematic = true;
            rb.useGravity = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Scene")
        {
            if (arrowType == ArrowType.Teleport)
                teleportPlayer.transform.position = transform.position;

            Debug.Log("Tp");

            shot = false;

            transform.SetParent(collision.transform);
            rb.isKinematic = true;
            rb.useGravity = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }
}
