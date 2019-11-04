using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpBar;
    public Text value;

    public void UpdateValues(int hp, int maxHp)
    {
        float aux = hp / (float)maxHp;
        value.text = hp + "/" + maxHp;
        hpBar.fillAmount = aux;
    }
}
