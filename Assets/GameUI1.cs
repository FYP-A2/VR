using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI1 : MonoBehaviour
{
    public Text arrowCount;
    public Text fireArrowCount;
    public Text freezeArrowCount;
    public Text tpArrowCount;
    public Text healingCount;
    public Image healthBar;
    public Text coinCount;
    public static int selectedArrowType = 0;
    public Bow bow;

    public void SetArrowCount(int arrow,int tp, int fire, int freeze)
    {
        arrowCount.text = "" + arrow;
        tpArrowCount.text = "" + tp;
        fireArrowCount.text = "" + fire;
        freezeArrowCount.text = "" + freeze;
    }

    public void SetHealthPotionCount(int n)
    {
        healingCount.text = "" + n;
    }

    public void SetHealth(float percentage)
    {
        healthBar.fillAmount = percentage;
    }

    public void SetCoin(float n)
    {
        coinCount.text = "" + n;
    }

    public void SelectArrow(int type)
    {
        selectedArrowType = type;
        bow.SetArrow();
    }
}
