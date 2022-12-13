using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int healthMax;
    public float speed;
    public GameUI1 gameUI1;

    public GameObject board1;
    public GameObject bow;
    public GameObject boardGameOver;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        gameUI1.SetHealth((float)health / healthMax);

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
        boardGameOver.SetActive(true);

        board1.SetActive(false);
        bow.SetActive(false);

        Time.timeScale = 0;
    }
}