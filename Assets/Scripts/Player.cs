using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Dead();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Dead()
    {
        Time.timeScale = 0;
    }
}