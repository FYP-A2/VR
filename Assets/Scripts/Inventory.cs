using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float coins;
    public GameObject[] ArrowPrefab;
    public int[] arrowCount = new int[4];
    public int HealthPotionCount;
    public GameUI1 ui;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ui.SetArrowCount(arrowCount[0], arrowCount[1], arrowCount[2], arrowCount[3]);
        ui.SetCoin(coins);
        ui.SetHealthPotionCount(HealthPotionCount);

    }

    public Arrow GetArrow(int type)
    {

        if (type == 0 && arrowCount[0] > 0)
            return Instantiate(ArrowPrefab[0]).GetComponent<Arrow>();
        else if (type == 1 && arrowCount[1] > 0)
            return Instantiate(ArrowPrefab[1]).GetComponent<Arrow>();
        else if (type == 2 && arrowCount[2] > 0)
            return Instantiate(ArrowPrefab[2]).GetComponent<Arrow>();
        else if (type == 3 && arrowCount[3] > 0)
            return Instantiate(ArrowPrefab[3]).GetComponent<Arrow>();
        else
            return null;
    }

    public void AddArrow(int n)
    {
        arrowCount[0] += n;
    }

    public void AddTpArrow(int n)
    {
        arrowCount[1] += n;
    }

    public void AddFireArrow(int n)
    {
        arrowCount[2] += n;
    }

    public void AddFreezeArrow(int n)
    {
        arrowCount[3] += n;
    }

    public void AddHealing(int n)
    {
        HealthPotionCount += n;
    }

    public void AddCoin(int n)
    {
        coins += n;
    }
}
