using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHPBar : MonoBehaviour
{

    public Image hpBar;

    private void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.back);
    }

    public void UpdateValues(int hp, int maxHp)
    {
        //hpBar.fillAmount = hp / (float)maxHp;
        StopCoroutine("LoadLife");
        StartCoroutine(LoadLife(hp / (float) maxHp));
    }

    IEnumerator LoadLife(float life)
    {
        while(hpBar.fillAmount > life)
        {
            hpBar.fillAmount -= Time.deltaTime;
            yield return null;
        }
        hpBar.fillAmount = life;
    }
}
